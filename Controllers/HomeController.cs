using System.Diagnostics;
using System.Reflection;
using CappypopMVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;

namespace CappypopMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Client supabase;

    public HomeController(ILogger<HomeController> logger, Client client)
    {
        _logger = logger;
        supabase = client;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Term()
    {
        return View();
    }
    public IActionResult Helpsupport()
    {
        return View();
    }
    public IActionResult Boba()
    {
        return View();
    }
    public IActionResult Aboutus()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
