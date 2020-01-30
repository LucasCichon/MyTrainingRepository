using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionExcersise.Models;
using DependencyInjectionExcersise.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionExcersise.Controllers
{
    public class HomeController : Controller
    {
        
        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            IRepository repository = HttpContext.RequestServices.GetService<IRepository>();
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            return View(repository.Products);
        }
        
        
        //public ViewResult Index() => View(new MemoryRepository().Products); // public IEnumerable<Product> Products => products.Values;
    }
}
