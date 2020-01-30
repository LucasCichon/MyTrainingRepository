using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;
        public CitySummary(ICityRepository repo) => repository = repo;

        public IViewComponentResult Invoke(bool showList) //!! To jest metoda która tworzy obiekt CityViewModel, dlatego w tabelce są liczby !!!
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }
            else
            {
                return View(new CityViewModel
                {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(p => p.Population)
                });
            }

            //string target = RouteData.Values["id"] as string;
            //var cities = repository.Cities.Where(citi => String.Compare(citi.Country, target, true) == 0 ||
            //target == null);

            //return View(new CityViewModel
            //{
            //    Cities = cities.Count(),
            //    Population = cities.Sum(p => p.Population)
            //});
            //return new HtmlContentViewComponentResult(
            //    new HtmlString("To jest <h3><i>ciąg tekstowy</i></h3>."));

            //return Content("To jest <h3><i>ciąg tekstowy</i></h3>");

            //return View(new CityViewModel
            //{
            //    Cities = repository.Cities.Count(),
            //    Population = repository.Cities.Sum(p => p.Population)
            //});
        }
       
    }
}
