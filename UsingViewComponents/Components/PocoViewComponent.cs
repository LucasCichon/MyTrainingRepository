using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingViewComponents.Components
{
    public class PocoViewComponent : Controller
    {
        private ICityRepository repository;
        public PocoViewComponent(ICityRepository repo) => repository = repo;

        public string Invoke()
        {
            return $"{repository.Cities.Count()} miasta, "
                + $"{repository.Cities.Sum(c => c.Population)} osób";
        }
    }
}
