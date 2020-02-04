using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orgella.Infrastructure;
using Orgella.Models;
using Orgella.Models.ViewModels;
using System.Linq;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orgella.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository repo) => repository = repo;

        public ViewResult Index(string returnUrl) => View(new CartIndexViewModel()
        {
            Cart = GetCart(),
            ReturnUrl = returnUrl
        });

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if(product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }       

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if(product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //metoda która zwraca koszyk z Sesji jeżeli istnieje
        //jeżeli nie to tworzy nowy
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        //metoda zapisuje koszyk w formacie json
       private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

    }
}
