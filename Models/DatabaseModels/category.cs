using Microsoft.AspNetCore.Mvc;

namespace CappypopMVC.Models.DatabaseModels
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
