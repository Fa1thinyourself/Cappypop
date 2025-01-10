using System.Diagnostics;
using System.Reflection;
using CappypopMVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;

namespace CappypopMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly Client supabase;

        public ProductController(ILogger<ProductController> logger, Client client)
        {
            _logger = logger;
            supabase = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await supabase.From<Products>().Get();
            var products = response.Models;
            return View(products);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) {
                return NotFound();
}
            var product = await supabase.From<Products>().Where(x => x.productid == id).Single();
            
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}