using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Orgella.Models;
using System.Linq;
using Orgella.Controllers;
using Orgella.Models.ViewModels;

namespace Orgella.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Send_Pagination_View_Mode()
        {
            //Przygotowanie.
            //Utworzenie repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{Name = "P1", ProductID = 1},
                new Product{Name = "P2", ProductID = 2},
                new Product{Name = "P3", ProductID = 3},
                new Product{Name = "P4", ProductID = 4},
                new Product{Name = "P5", ProductID = 5},
            }.AsQueryable<Product>());

            //Przygotowanie - utworzenie kontrolera i ustawienie 3 elementowej strony
            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };
            
            //Działanie.
            //Wywołanie akcji list z i zwrócenie jej jako ViewData.Model do obiektu result
            ProductListViewModel result = controller.List(null,2).ViewData.Model as ProductListViewModel;

            //Asercje.
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.Equal(3, pagingInfo.ItemsPerPage);
            Assert.Equal(2, pagingInfo.TotalPages());
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal(2, result.PagingInfo.CurentPage);

        }


        [Fact]
        public void Can_Paginate()
        {
            //Przygotowanie.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {Name = "P1", ProductID = 1},
                new Product {Name = "P2", ProductID = 2},
                new Product {Name = "P3", ProductID = 3},
                new Product {Name = "P4", ProductID = 4},
                new Product {Name = "P5", ProductID = 5}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel result = controller.List(null,2).ViewData.Model as ProductListViewModel;
            

            //Asercje.
            Product[] prodArr = result.Products.ToArray();
            Assert.True(result.Products.Count() == 2);
            Assert.Equal(prodArr[0].Name , "P4");
            Assert.Equal(prodArr[1].Name , "P5");
        }
        [Fact]
        public void CanFilterProducts()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {Name = "P1", ProductID = 1, Category="C1"},
                new Product {Name = "P2", ProductID = 2, Category="C2"},
                new Product {Name = "P3", ProductID = 3, Category="C1"},
                new Product {Name = "P4", ProductID = 4, Category="C2"},
                new Product {Name = "P5", ProductID = 5, Category="C1"}
            }.AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel result = controller.List("C2", 1).ViewData.Model as ProductListViewModel;
            Product[] products = result.Products.ToArray();

            Assert.True(products.Length == 2);
            Assert.Equal(products[0].Name, "P2");
            Assert.Equal(products[1].Name, "P4");
        }
    }
}
