using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public StatusCodeResult Index() => NotFound();

        //public StatusCodeResult Index() => StatusCode(StatusCodes.Status404NotFound);

        //public VirtualFileResult Index() =>
        //    File("/lib/twitter-bootstrap/css/bootstrap.css", "text/css");

        //public ObjectResult Index() =>
        //    Ok(new string[] { "Alicja", "Bartek", "Janek" });

        //public ContentResult Index() =>
        //    Content("[\"Alicja\",\"Bartek\",\"Janek\"]", "applicationa/json");

        //public JsonResult Index() => Json(new[] {"Alicja", "Bartek", "Janek" });

        //public ViewResult Index()
        //{
        //    ViewBag.Message = "Witaj";
        //    ViewBag.Date = DateTime.Now;
        //    return View();
        //}
        
        //public ViewResult Index() => View(DateTime.Now);
        public ViewResult Result() => View((object)"Witaj, świecie");

        public RedirectToActionResult Redirect() => RedirectToAction("Index", "Home");

        //public RedirectToRouteResult Redirect() =>
        //    RedirectToRoute(new
        //    {
        //        controller = "Example",
        //        action = "Index",
        //        ID = "MyID"
        //    });


       // public RedirectResult Redirect() => RedirectPermanent("/Example/Index");
    }
}
