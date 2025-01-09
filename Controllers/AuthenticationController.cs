using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;
using Supabase.Gotrue.Exceptions;
using CappypopMVC.Models.DatabaseModels;

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

	public IActionResult Register()
	{
		return View();
	}

	// POST: Login
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login([Bind("Email,Password")] LoginViewModel users)
	{
		try
		{
			var session = await supabase.Auth.SignIn(users.Email, users.Password) ?? throw new Exception("Invalid credentials");
			if (session.AccessToken == null)
			{
				throw new Exception("Cannot found AccessToken");
			}
			HttpContext.Session.SetString("AccessToken", session.AccessToken);
			if (session.RefreshToken == null)
			{
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

	// POST: Register
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register([Bind("DisplayName,Email,PhoneNumber,Password")] RegisterViewModel newUser)
	{
		try
		{
			var session = await supabase.Auth.SignUp(newUser.Email, newUser.Password) ?? throw new Exception("User already registered");
			Users user = new()
			{
				Email = newUser.Email,
				FullName = newUser.DisplayName,
				PhoneNumber = newUser.PhoneNumber,
				UserUid = session.User?.Id,
				RoleId = 1,
			};
			await supabase.From<Users>().Insert(user);
			//if (session.AccessToken == null)
			//{
			//	throw new Exception("Cannot found AccessToken");
			//}
			//HttpContext.Session.SetString("AccessToken", session.AccessToken);
			//if (session.RefreshToken == null)
			//{
			//	throw new Exception("Cannot found RefreshToken");
			//}
			//HttpContext.Session.SetString("RefreshToken", session.RefreshToken);
			return RedirectToAction("Index");
		}
		catch (GotrueException error)
		{
			ModelState.AddModelError("Gotrue Auth", error.Message);
		}
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}

public class LoginViewModel
{
	public required string Email { get; set; }
	public required string Password { get; set; }
}

public class RegisterViewModel
{
	public required string DisplayName { get; set; }
	public required string Email { get; set; }
	public required string PhoneNumber { get; set; }
	public required string Password { get; set; }
}
