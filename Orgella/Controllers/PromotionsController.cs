using Microsoft.AspNetCore.Mvc;
using Orgella.Models;
using Orgella.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Controllers
{
    public class PromotionsController : Controller
    {
        private IProductRepository repository;
        public PromotionsController(IProductRepository repo) => repository = repo;

        public int PageSize = 4;

        public ViewResult List(string category, int productPage = 1) => View("Promotions", new ProductListViewModel()
        {
            Products = repository.Products
            .OrderBy(p => p.ProductID)
            .Where(c => category == null || c.Category == category)
            .Where(c => c.OldPrice != null)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null ? repository.Products.Count() :
                repository.Products.Where(p => p.Category == category).Count()
            },
            CurrentCategory = category

        });
    }
}
