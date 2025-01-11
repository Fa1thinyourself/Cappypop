using System.Diagnostics;
using System.Reflection;
using CappypopMVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;

namespace CappypopMVC.Controllers
{
    public class CappylifeController : Controller
    {
        private readonly ILogger<CappylifeController> _logger;
        private readonly Client supabase;

        public CappylifeController(ILogger<CappylifeController> logger, Client client)
        {
            _logger = logger;
            supabase = client;
        }
        public async Task<IActionResult> Index()
        {
            var response = await supabase.From<Cappylife>().Get();
            var cappylife = response.Models;
            return View(cappylife);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cappylife = await supabase.From<Cappylife>().Where(x => x.Id == id).Single();

            if (cappylife == null)
            {
                return NotFound();
            }
            return View(cappylife);
        }
    }
}