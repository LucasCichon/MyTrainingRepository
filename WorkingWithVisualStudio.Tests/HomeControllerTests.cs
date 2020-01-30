using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using System;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            //przygotowanie
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };
            //działanie
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //asercje
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>
                ((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        
        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //Przygotowanie
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };
            //Działanie
            var result = controller.Index();
            //Asercje
            mock.VerifyGet(m => m.Products, Times.Once);

        }
    }
}
