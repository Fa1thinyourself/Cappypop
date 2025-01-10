using CappypopMVC.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Helper;
using Supabase;
using CappypopMVC.Models.DatabaseModels;

namespace CappypopMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Client supabase;

        public CartController(ILogger<HomeController> logger, Client client)
        {
            _logger = logger;
            supabase = client;
        }

        const string CART_KEY = "MyCurrentCart";

        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }

        public async Task<IActionResult> AddToCart(int id, string size, int quantity, string sugar, string ice, string topping)
        {
            var currentCart = Cart;
            var cartSingleItem = currentCart.SingleOrDefault(p => p.Id == id);
            if (cartSingleItem == null)
            {
                var product = await supabase.From<Products>().Where(x => x.productid == id).Single();
                if (product == null)
                {
                    return NotFound();
                }
                cartSingleItem = new CartItem
                {
                    Id = product.productid ?? 0,
                    Name = product.Productname ?? "",
                    Image = product.BaseUrl ?? "",
                    Price = product.Price ?? 0,
                    Quantity = quantity,
                    Sugar = sugar,
                    Ice = ice,
                    Topping = topping,
                    Size = size
                };
                currentCart.Add(cartSingleItem);
            }
            else
            {
                cartSingleItem.Quantity += quantity;
            }
            HttpContext.Session.Set(CART_KEY, currentCart);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCartItem(int id){
            var currentCart = Cart;
            var itemToRemove = currentCart.Single(item => item.Id == id);
            currentCart.Remove(itemToRemove);
            HttpContext.Session.Set(CART_KEY, currentCart);
            return RedirectToAction("Index");
        }
    }
}
