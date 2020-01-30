using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orgella.Models;
using Orgella.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orgella.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepository repository;
        public AdminController(IAdminRepository repo) => repository = repo;
        public int pageSize = 5;

        public ViewResult List(int adminPage = 1) => View(new AdminListViewModel() 
        {   Admins = repository.Admins
            .OrderBy(a => a.AdminID)
            .Skip((adminPage - 1) * pageSize)
            .Take(pageSize),
            PagingInfo = new PagingInfo()
            {
                TotalItems = repository.Admins.Count(),
                ItemsPerPage = pageSize,
                CurentPage = adminPage
            }
        });
        
    }
}
