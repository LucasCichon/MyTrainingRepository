using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvitesExcersise.Models;

namespace PartyInvitesExcersise.Controllers
{
    public class HomeController : Controller
    {
       
        public ViewResult Index()
        {
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
            }
            else
            {
                //błąd kontroli poprawnośi danych
                return View();
            }
        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }

        
    }
}
