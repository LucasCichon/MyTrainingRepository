using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvitesCode.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyInvitesCode.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController (IRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 17 ? "Dzień Dobry!" : "Dobry wieczór";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm() => View();

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
                repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                //błąd kontroli poprawnośći
                return View();
            }
        }
        public ViewResult ListResponse() =>
            View(repository.Responses.Where(r => r.WillAttend == true));
    }
}
