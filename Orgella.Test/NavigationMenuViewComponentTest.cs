using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using Orgella.Components;
using Orgella.Controllers;
using Orgella.Models;
using Orgella.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Orgella.Test
{
    public class NavigationMenuViewComponentTest
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //Przygotowanie
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(c => c.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category = "Jabłka"},
                new Product{ProductID = 2, Name = "P2", Category = "Jabłka"},
                new Product{ProductID = 3, Name = "P3", Category = "Śliwki"},
                new Product{ProductID = 4, Name = "P4", Category = "Pomarańcze"},
            }.AsQueryable<Product>()));

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            string[] result = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray(); //ViewViewComponentResult obiekt renderujący widok częściowy

            //metoda Invoke zwraca same kategorie

            Assert.True(Enumerable.SequenceEqual(new string[] { "Jabłka", "Pomarańcze", "Śliwki" }, result));

        }

        [Fact]
        public void Indicates_Selecteg_Category()
        {
            //Przygotowanie
            string categoryToSelect = "Jabłka";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product{ProductID = 1, Name="P1", Category = "Jabłka"},
                new Product{ProductID = 4, Name="P2", Category = "Pomarańcze"}
                }.AsQueryable<Product>()));

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;

            //Działanie.
            //Selected kategory to wartość ViewBag w NavigationMenuViewComponent
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            //Asercje.
            Assert.Equal(categoryToSelect, result);
        }
        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            //Przygotowanie.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category="Cat1"},
                new Product{ProductID = 2, Name = "P2", Category="Cat2"},
                new Product{ProductID = 3, Name = "P3", Category="Cat1"},
                new Product{ProductID = 4, Name = "P4", Category="Cat2"},
                new Product{ProductID = 5, Name = "P5", Category="Cat3"}
            }).AsQueryable<Product>());

            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;

            Func<ViewResult, ProductListViewModel> GetModel = result => result?.ViewData.Model as ProductListViewModel;

            //Działanie.
            int? res1 = GetModel(target.List("Cat1")) ?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.List("Cat2")) ?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.List("Cat3")) ?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.List(null)) ?.PagingInfo.TotalItems;

            //Asercje.
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);

        }

    }
}
