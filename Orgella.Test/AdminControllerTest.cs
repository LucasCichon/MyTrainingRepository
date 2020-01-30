using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Orgella.Models;
using System.Linq;
using Orgella.Controllers;
using Orgella.Models.ViewModels;

namespace Orgella.Test
{
    public class AdminControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IAdminRepository> mock = new Mock<IAdminRepository>();
            mock.Setup(a => a.Admins).Returns((new Admin[] {
                new Admin { FirstName = "A1", AdminID = 1 },
                new Admin { FirstName = "A2", AdminID = 2 },
                new Admin { FirstName = "A3", AdminID = 3 },
                new Admin { FirstName = "A4", AdminID = 4 },
                new Admin { FirstName = "A5", AdminID = 5 }
            }).AsQueryable<Admin>());

            AdminController controller = new AdminController(mock.Object);
            controller.pageSize = 3;

            AdminListViewModel result = controller.List(2).ViewData.Model as AdminListViewModel;

            //Asercje.
            Admin[] Admins = result.Admins.ToArray();
            Assert.True(result.Admins.Count() == 2);
            Assert.Equal(2, Admins.Length);
            Assert.Equal(Admins[0].FirstName, "A4");
            Assert.Equal(Admins[1].FirstName, "A5");

        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IAdminRepository> mock = new Mock<IAdminRepository>();
            mock.Setup(a => a.Admins).Returns((new Admin[]
            {
                new Admin{FirstName = "A1", AdminID = 1},
                new Admin{FirstName = "A2", AdminID = 2},
                new Admin{FirstName = "A3", AdminID = 3},
                new Admin{FirstName = "A4", AdminID = 4},
                new Admin{FirstName = "A5", AdminID = 5}
            }.AsQueryable<Admin>));

            AdminController controller = new AdminController(mock.Object);
            controller.pageSize = 3;

            AdminListViewModel result = controller.List(2).ViewData.Model as AdminListViewModel;

            PagingInfo pagingInfo = result.PagingInfo;

            Assert.Equal(pagingInfo.CurentPage, 2);
            Assert.Equal(pagingInfo.ItemsPerPage, 3);
            Assert.Equal(pagingInfo.TotalItems, 5);
            Assert.Equal(pagingInfo.TotalPages(), 2);


        }
    }
}
