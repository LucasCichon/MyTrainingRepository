using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiControllers.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository { get; set; }
        public HomeController(IRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }

    }
}
