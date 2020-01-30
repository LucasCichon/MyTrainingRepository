using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parafia.Models;

namespace Parafia.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ICategoryRepository repository;

        public NavigationMenuViewComponent(ICategoryRepository repo) => repository = repo;

        public IViewComponentResult Invoke()
        {
            return View(repository.Categories);
        }
    }
}
