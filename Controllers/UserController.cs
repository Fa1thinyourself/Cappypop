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
        public IActionResult Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            return View();
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