using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;

namespace SportsStore.Test
{
    public class AdminControllerTest
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            // Przygotowanie - utworzenie imitacji repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            }.AsQueryable<Product>());
            //Przygotowanie - utworzenie kontrolera
            AdminController target = new AdminController(mock.Object);

            //Działanie
            Product[] result = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();

            //Asercje
            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].Name);
            Assert.Equal("P2", result[1].Name);
            Assert.Equal("P3", result[2].Name);
        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void Can_Edit_Product()
        {
            //Przygotowanie - tworzenie repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            }.AsQueryable());
            //Przygotowanie - utworzenie konteolra
            AdminController target = new AdminController(mock.Object);

            //Działanie
            Product p1 = GetViewModel<Product>(target.Edit(1));
            Product p2 = GetViewModel<Product>(target.Edit(2));
            Product p3 = GetViewModel<Product>(target.Edit(3));

            //Asercje
            Assert.Equal(1, p1.ProductID);
            Assert.Equal(2, p2.ProductID);
            Assert.Equal(3, p3.ProductID);
        }
        [Fact]
        public void Cannot_Edit_Nonexisten_Product()
        {
            //Przygotowanie - utworzenie imitacji repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            }.AsQueryable<Product>());
            //Przygotowanie - utworzenie kontrolera
            AdminController target = new AdminController(mock.Object);
            //Działanie
            Product result = GetViewModel<Product>(target.Edit(4));
            //Assercje
            Assert.Null(result);
        }
        [Fact]
        public void Save_Valid_Changes()
        {
            //Przygotowanie - utworzenie imitacji repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //Przygotowanie - tworzenie imitacji kontenera TempData
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            //Przygotowanie - tworzenie kontrolera
            AdminController target = new AdminController(mock.Object)
            {
                TempData = tempData.Object
            };
            //Przygotowanie - tworzenie produktu
            Product product = new Product { Name = "Test" };

            //Działanie - próba zapisania produktu
            IActionResult result = target.Edit(product);

            //Asercje - sprawdzenie, czy zostło wywołane repozytorium.
            mock.Verify(m => m.SaveProduct(product));
            //Asercje - zprawdzenie typu zwracanego z metody.
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
        }
        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            //Przygotowanie - tworzenie imitacji repozytorium.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //Przygotowanie - tworzenie kontrolera.
            AdminController target = new AdminController(mock.Object);
            //Przygotowanie - tworzenie produktu
            Product product = new Product { Name = "Test" };
            //Przygotowanie - dodanie błędu do stanu modelu.
            target.ModelState.AddModelError("error", "error");

            //Działanie - próba zapisania produktu.
            IActionResult result = target.Edit(product);

            //Asercje - sprawdzenie, czu nie zostało wywołane repozytorium
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            //Asercje - sprawdzenie typu zwracanego z metody
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Can_Delete_Product()
        {
            Product product = new Product { ProductID = 2, Name = "Test" };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Name = "P1", ProductID = 1},
                product,
                new Product {Name = "P3", ProductID = 3}
            }.AsQueryable<Product>());

            //przygotowanie - tworzenie kontrolera
            AdminController target = new AdminController(mock.Object);
            //Działanie
            target.Delete(product.ProductID);
            //Asercje - upewniamy się, że metoda repozytorium została wywołana z właściwym produktem.
            mock.Verify(m => m.DeleteProduct(product.ProductID));
            
        }
    }
}
