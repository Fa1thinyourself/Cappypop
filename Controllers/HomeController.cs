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
        var response = await supabase.From<Users>().Get();
        List<Users> users = response.Models;

        users.ForEach(user =>
        {
            PropertyInfo[] p = user.GetType().GetProperties();
            foreach (PropertyInfo item in p)
            {
                Console.WriteLine(item.Name + ": " + item.GetValue(user));
            };
        });
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
