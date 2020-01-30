using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreExcersise.Models;
using SportsStoreExcersise.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStoreExcersise.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;
        private IProductRepository repository;
        public ProductController (IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int ProductPage = 1) => View(new ProductsListViewModel   //przekazanie obiektu ProductsListViewModel jako danych modelu dla widoku
        {
            Products = repository.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((ProductPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = ProductPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null
                ? repository.Products.Count() 
                : repository.Products.Where(p => p.Category == category).Count()
            },
            CurrentCategory = category
        });
    }
}
