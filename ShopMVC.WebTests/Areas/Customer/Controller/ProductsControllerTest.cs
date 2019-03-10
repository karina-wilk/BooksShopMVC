using Moq;
using NUnit.Framework;
using ShopMVC.Model.Entities;
using ShopMVC.Services.Books;
using ShopMVC.Web.Areas.AdminArea.Controllers;
using ShopMVC.Web.Areas.AdminArea.Models;
//using ShopMVC.Web.Areas.Customer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShopMVC.WebTests.Areas.Customer.Controller
{
    [TestFixture]
    class ProductsControllerTest
    {
        [Test]
        public async Task Index_IsGetListAsync_CalledOnce()
        {
            //Arrange
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(c => c.GetListAsync())
                            .ReturnsAsync(new List<Book>());
            var controller = new ProductsController(bookServiceMock.Object);

            //Act
            var result = await controller.Index();

            //Assert
            bookServiceMock.VerifyAll();
        }

        [Test]
        public async Task Index_CallsGetListAsync_ReturnsValidModel()
        {
            //Arrange
            var fakeBooksList = new List<Book>
            {
                new Book{ Id=555, Title="Bob Builder"},
                new Book{ Id=455, Title="Batman"},
                new Book{ Id=789, Title="Winnie the Pooh"},
            };
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(c => c.GetListAsync())
                .ReturnsAsync(fakeBooksList);

            var controller = new ProductsController(bookServiceMock.Object);

            //Act
            var result = await controller.Index();
            var vResult = result as ViewResult;

            //Assert
            Assert.AreEqual(vResult.Model.GetType(), typeof(List<BookDisplayModel>));

            var returnedModel = vResult.Model as List<BookDisplayModel>;
            Assert.AreEqual(fakeBooksList[0].Id, returnedModel[0].Id);
            Assert.AreEqual(fakeBooksList[2].Title, returnedModel[2].Title);
            Assert.AreEqual("Batman", returnedModel[1].Title);
        }

    }
}
