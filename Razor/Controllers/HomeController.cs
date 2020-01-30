using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Product [] array = 
            {
               new Product{Name = "Kajak", Price = 275M},
               new Product{Name = "Kamizelka Ratunkowa", Price = 48.95M},
               new Product{Name = "Piłka nożna", Price = 19.50M},
               new Product{Name = "Flaga narożna", Price = 34.95M}
            };
            ViewBag.StockLevel = 2;

            Sport MySport = new Sport
            {
                Name = "Kolarstwo Górskie",
                Category = "Bike Ride",
                Where = "outside"
            };

        return View(array);
        }
    }
}