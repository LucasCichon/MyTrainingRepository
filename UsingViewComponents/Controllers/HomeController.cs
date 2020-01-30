using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingViewComponents.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public HomeController(IProductRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Products);
        public ViewResult Create() => View();

        [HttpPost]
        public ActionResult Create(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}
