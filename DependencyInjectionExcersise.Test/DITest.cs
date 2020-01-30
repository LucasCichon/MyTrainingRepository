using DependencyInjectionExcersise.Controllers;
using DependencyInjectionExcersise.Infrastructure;
using DependencyInjectionExcersise.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DependencyInjectionExcersise.Test
{
    public class DITest
    {
        [Fact]
        public void ControllerTest()
        {
            //Przygotowanie.
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);            
            HomeController controller = new HomeController(mock.Object);

            //Działanie.
            ViewResult result = controller.Index();

            //Asercje.
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
