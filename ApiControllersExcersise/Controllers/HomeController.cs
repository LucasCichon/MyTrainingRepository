using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiControllersExcersise.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiControllersExcersise.Controllers
{
    public class HomeController : Controller
    {
        public IRepository repository { get; set; }
        public HomeController(IRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Reservations);

        [HttpPost]
        public ActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}
