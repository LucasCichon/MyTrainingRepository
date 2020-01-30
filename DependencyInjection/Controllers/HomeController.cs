using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        

        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            IRepository repository = HttpContext.RequestServices.GetService<IRepository>();
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            //ViewBag.Total = totalizer.Total;
            return View(repository.Products);
        }
        //framework MVC jest odpowiedzialny za tworzenie egzemplasza kontrolera przeznaczonego do przetwarzania żądania i nic nie wie na temat specjalnej wagi właściwości Repository. Efektem zastosowania tej techniki jest luźne powiązanie kontrolera i repozytorium na potrzeby testów jednostkowych, a jednocześnie silne ich powiązanie w działającej aplikacji.
        //public IRepository Repository { get;  } = TypeBroker.Repository;
        //public ViewResult Index() => View(Repository.Products);
    }
}
