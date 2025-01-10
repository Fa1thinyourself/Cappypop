using System.Diagnostics;
using System.Reflection;
using CappypopMVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;

namespace CappypopMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Client supabase;

        public UserController(ILogger<HomeController> logger, Client client)
        {
            _logger = logger;
            supabase = client;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }

            var user = await supabase.From<Users>().Where(u => u.UserUid == supabase.Auth.CurrentUser!.Id).Single();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile([Bind("FullName,PhoneNumber")] UpdateViewModel updateUser)
        {
            await supabase.From<Users>()
                .Where(u => u.UserUid == supabase.Auth.CurrentUser!.Id)
                .Set(x => x.FullName, updateUser.FullName)
                .Set(x => x.PhoneNumber, updateUser.PhoneNumber)
                .Update();
            return RedirectToAction("Index");
        }


        public IActionResult Address()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            return View();
        }
        public IActionResult Cart()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            return View();
        }
        public IActionResult Checkout()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            return View();
        }
        public IActionResult Notification()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            return View();
        }
        public IActionResult Orderhistory()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            return View();
        }
    }
}

public class UpdateViewModel
{
    public string FullName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
}