using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking",new Apointment() { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Apointment apt)
        {
           
            if(ModelState.GetValidationState(nameof(apt.ClientName))==ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(apt.Date)) == ModelValidationState.Valid
                && apt.ClientName.Equals("Janek",StringComparison.OrdinalIgnoreCase)
                && apt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Janek nie może rezerwować wizyt w poniedziałki");
            }
            if (ModelState.IsValid)
            {
                return View("Completed", apt);
            }
            else
            {
                return View();
            }
        }

        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;

            if(!DateTime.TryParse(Date, out parsedDate))
            {
               
                return Json("Proszę podać prawidłową datę (dd.mm.rrrr).");
            }
            else if(DateTime.Now > parsedDate)
            {
                return Json("Proszę podać datę w przyszłośći.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
