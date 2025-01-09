using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;
using Supabase.Gotrue.Exceptions;

namespace CappypopMVC.Controllers;

public class AuthenticationController : Controller
{
	private readonly ILogger<AuthenticationController> _logger;
	private readonly Client supabase;

	public AuthenticationController(ILogger<AuthenticationController> logger, Client client)
	{
		_logger = logger;
		supabase = client;
	}

	public IActionResult Index()
	{
		return View();
	}

	// POST: Login
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login([Bind("Email,Password")] AuthenticationViewModel users)
	{
		try
		{
			var session = await supabase.Auth.SignIn(users.Email, users.Password) ?? throw new Exception("Invalid credentials");
			if (session.AccessToken == null) {
				throw new Exception("Cannot found AccessToken");
			}
			HttpContext.Session.SetString("AccessToken", session.AccessToken);
			if (session.RefreshToken == null) {
				throw new Exception("Cannot found RefreshToken");
			}
			HttpContext.Session.SetString("RefreshToken", session.RefreshToken);
			return RedirectToAction("Index", "Home");
		}
		catch (GotrueException error)
		{
			ModelState.AddModelError("InvalidCredentials", error.Message);
		}
		catch (Exception ex)
		{
			ModelState.AddModelError("Supabase", ex.Message);
		}

		return View("Index");
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}

public class AuthenticationViewModel
{
	public required string Email { get; set; }
	public required string Password { get; set; }
}
