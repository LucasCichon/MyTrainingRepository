using Microsoft.AspNetCore.Mvc;
using Orgella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Components
{
    //View komponent to taki mini kontroller. zawiera niewielką ilość logiki, która użyta jest do obsługi widoku częściowego "Views/Shared/Component/**" taka obsługa małych elementów na stronie któą można łatwo osobno przetestować
    public class NavigationMenuViewComponent : ViewComponent //abstract class
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo) => repository = repo;

        public IViewComponentResult Invoke()
        {
            //właściwość SelectedCategory jest dynamiczne przypisywana obiektowi ViewBag. Wartością tej właściwości jest bieżąca kategoria pobrana z obiektu kontekstu zwróconego przez właściwość RouteData. 
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
