using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.Models;
using SportsStore.Components;
using Xunit;

namespace SportsStore.Test
{
    public class NavigationMenuVIewComponentTest
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //Przygotowanie.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category = "Jabłka"},
                new Product{ProductID = 2, Name = "P2", Category = "Jabłka"},
                new Product{ProductID = 3, Name = "P3", Category = "Śliwki"},
                new Product{ProductID = 4, Name = "P4"}
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);

            //Działanie - pobranie zbioru kategorii
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            //Asercje.
            Assert.False(Enumerable.SequenceEqual(new string[] { "Jabłka", "Pomarańcze", "Śliwki" }, results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            //Przygotowanie.
            string categoryToSelect = "Jabłka";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = "Jabłka"},
                new Product {ProductID = 4, Name = "P2", Category = "Pomarańcze"},
            }).AsQueryable<Product>());

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
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            //Arescje.
            Assert.Equal(categoryToSelect, result);

        }
    }
}
