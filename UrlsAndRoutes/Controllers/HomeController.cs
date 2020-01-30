using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Result", //metoda wywołuje widok o nazwie Result i dostarcza obiekt typu Result jako model
            // właściwości obiektu modelu są konfigurowane za pomocą funkcji nameof() i zostaną użyte do wskazania kontrolera oraz metody akcji przeznaczonej do obsłużenia żądania.
            new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            r.Data["id"] = id ?? "<brak wartości>";
            r.Data["url"] = Url.Action("CustomVariable", "Home", new { id = 100 });
            return View("Result", r);
        }
    }
}
