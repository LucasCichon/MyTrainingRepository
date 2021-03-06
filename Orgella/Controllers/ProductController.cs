﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orgella.Models;
using Orgella.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orgella.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo) => repository = repo;

        // obiekt ProductsListViewModel przyjmuje wartośći IEnumerabel<Product> i Paging info
        public ViewResult List(string category, int productPage = 1) => View(new ProductListViewModel() 
        {
            Products = repository.Products
            .OrderBy(p => p.ProductID)
            .Where(c => category==null || c.Category == category)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = category==null ? repository.Products.Count() :
                repository.Products.Where(p => p.Category == category).Count()
            },
            CurrentCategory = category

        });
        public ViewResult Search(string category, string word="", int productPage = 1) => View("List",new ProductListViewModel()
        {
            Products = repository.Products
            .Where(p => p.Name.ToLower().Contains(word.ToLower()) || p.Category.ToLower().Contains(word.ToLower()))
            .OrderBy(p => p.Name)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products
                    .Where(p => p.Name.ToLower().Contains(word.ToLower()) || p.Category.ToLower().Contains(word.ToLower())).Count()
            },
            CurrentCategory = category
        });
            
    }
}
