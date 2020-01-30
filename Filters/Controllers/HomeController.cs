using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filters.Infrastructure;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filters.Controllers
{   //[HttpsOnly]
    //[Profile]
    //[ViewResultDetails]
    //[RangeException]
    //[RequireHttps] - filtr można zastosować dla całej klasy kontrolera
    //[TypeFilter(typeof(DiagnosticFilter))]
    //[ServiceFilter(typeof(TimeFilter))]
    [Message("To jest filtr o zasięgu kontrolera", Order =10)]
    public class HomeController : Controller
    {
        //[RequireHttps]
        [Message("To jest pierwszy filtr o zasięgu kontrolera", Order =1)]
        [Message("To jest drugi filtr o zasięgu akcji", Order =1)]
        public ViewResult Index() => View("Message", "To jest metoda akcji Index() kontrolera HomeController!");

        //[RequireHttps]
        //public ViewResult SendAction() => View("Message", "To jest metoda akcji SendAction() kontrolera HomeController!");

        //public ViewResult GenerateException(int? id)
        //{
        //    if (id == null)
        //    {
        //        throw new ArgumentNullException(nameof(id));
        //    }
        //    else if (id > 10)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(id));
        //    }
        //    else
        //    {
        //        return View("Message", $"Wartość wynosi {id}.");
        //    }
        //}
        
    }
}
