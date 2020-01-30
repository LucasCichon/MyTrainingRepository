using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Controllers;
using DependencyInjection.Models;
using Moq;
using Xunit;
using System.Collections.Generic;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Test
{
    public class DITest
    {
        [Fact]
        public void ControllrTest()
        {
            //Przygotowanie.
            var data = new[] { new Product{ Name = "Test", Price = 100 } }; //tworzymy nową tablicę Product z jednym produktem
            var mock = new Mock<IRepository>(); //tworzymy imitację repozytorium
            mock.SetupGet(m => m.Products).Returns(data);   //?
            //TypeBroker.SetTestObject(mock.Object);
            HomeController controller = new HomeController(mock.Object);
            

            //Działanie.
            ViewResult result = controller.Index();

            //Asercje.
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
