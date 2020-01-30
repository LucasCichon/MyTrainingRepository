using Microsoft.AspNetCore.Mvc;
using SportsStoreExcersise.Models;
using System.Collections.Generic;
using System.Linq;


namespace SportsStoreExcersise.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()                 //różny, odmienny, odrębny - dzięku tej metodzie każda kategoria wyświetlana jest tylko raz
                .OrderBy(x => x));
        }  
    }
}
