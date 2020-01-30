using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreExcersise.Models;
using SportsStoreExcersise.Models.ViewModels;
using SportsStoreExcersise.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStoreExcersise.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart (int productId, string returnUrl)
        {
            //przypisujemy obiektowi produkt pierwszy obiek z repozytorium o ID ronum id podanym w parametrze matody
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId); 
            //Jezeli udało się utworzyc obiekt product dodajemy go to koszyka( czyli jeżeli był obiekt o podanym ID w repozytorium)
            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            //szukamy czy w repozytoirum jest obiekt o podanym ID. Jeżeli jest taki obiekt, wtety przypisujemy go naszemu obiektowi produkt
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            // jeżeli udało się przypiać obiekt do referencji? usuwamy z koszyka obiekt o podanym ID
            if(product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
