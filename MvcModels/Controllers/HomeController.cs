using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repo) { repository = repo; }

        public IActionResult Index([FromQuery]int? id) 
        {
            Person person;
            if(id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            else if (!id.HasValue)
            {
                return View(repository.People.First());
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public Person Body([FromBody]Person model) => model;

       // public string Header([FromHeader(Name ="Accept-Language")] string accept) => $"Nagłówek: {accept}";


        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("index", model);

        public ViewResult DisplaySummary([Bind(nameof(AdressSummary.City), Prefix =nameof(Person.HomeAdress))]AdressSummary summary) => View(summary);

        public ViewResult Names(IList<string>names) => View(names ?? new List<string>());

        public ViewResult Adress(List<AdressSummary> adresses) => View( adresses ?? new List<AdressSummary>());
    }
}
