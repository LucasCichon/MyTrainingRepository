using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //właściwość SelectedCategory jest dynamiczne przypisywana obiektowi ViewBag. Wartością tej właściwości jest bieżąca kategoria pobrana z obiektu kontekstu zwróconego przez właściwość RouteData. 
            
            return View();
        }
    }
}
