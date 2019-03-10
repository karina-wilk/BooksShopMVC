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

        [Test]
        public async Task Index_GetListAsyncReturnsNull_ReturnsValidModel()
        {
            //Arrange
            List<Book> fakeBooksList = null;
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
            Assert.AreEqual(0, returnedModel.Count);
        }

        [Test]
        public async Task CreatePost_CategoriesNull_ReturnsNotFound()
        {
            //Arrange
            var bookServiceMock = new Mock<IBookService>();
            List<BookCategory> fakeCategories = null;
            bookServiceMock.Setup(c => c.GetCategoriesAsync())
                .ReturnsAsync(fakeCategories);

            var controller = new ProductsController(bookServiceMock.Object);

            //Act
            var result = await controller.Create();

            //Assert
            Assert.AreEqual(result.GetType(), typeof(HttpNotFoundResult));
        }

        [Test]
        public async Task CreatePost_CallsGetCategoriesAsync_ReturnsValidModel()
        {
            //Arrange
            List<BookCategory> fakeCategories = new List<BookCategory>
            {
                new BookCategory{ Id=22, Name="Science"},
                new BookCategory{ Id=24, Name="Romance"},
            };
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(c => c.GetCategoriesAsync())
                .ReturnsAsync(fakeCategories);
            var controller = new ProductsController(bookServiceMock.Object);

            //Act
            var result = await controller.Create();
            var vResult = result as ViewResult;

            //Assert
            Assert.AreEqual(typeof(BookEditModel), vResult.Model.GetType());
            Assert.AreEqual(3, (vResult.Model as BookEditModel).Categories.Count);
            Assert.AreEqual("Romance", (vResult.Model as BookEditModel).Categories[2].Text);
            Assert.AreEqual(null, (vResult.Model as BookEditModel).Categories[0].Text);
        }
    }
}
