using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cities.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController (IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Cities);
        public ViewResult Create() => View();
        [HttpPost]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index");
        }
    }
}
