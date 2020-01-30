using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            uptime = up;
            logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Obsłużone żądanie {Request.Path}, {uptime.Uptime}ms po uruchomieniu aplikacji.");

            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "To jest metoda akcji o nazwie Index()",
                ["Uptime"] = $"{uptime.Uptime}ms"
            });
        }
        public ViewResult Error() => View(nameof(Index),
        new Dictionary<string, string>
        {
            ["Message"] = "To jest metoda akcji o nazwie Error()"
        });
    }
}
