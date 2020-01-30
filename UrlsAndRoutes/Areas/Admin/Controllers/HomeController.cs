using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Areas.Admin.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private Person[] data = new Person[]
        {
            new Person {Name="Alicja",City="Londyn"},
            new Person {Name="Bartek",City="Paryż"},
            new Person {Name="Janek",City="Nowy Jork"}
        };
        public ViewResult Index() => View(data);
    }
}
