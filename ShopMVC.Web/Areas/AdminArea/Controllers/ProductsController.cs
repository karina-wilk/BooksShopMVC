using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using ShopMVC.Domain.Services.Books;
using ShopMVC.Web.Areas.AdminArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/admin/products")]
    public class ProductsController : Controller
    {
        IBookService bookService;

        public ProductsController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ProductsController()
        {
            this.bookService = new BookService();
        }
       
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            ViewBag.ActionTitle = "All books";
            var books = await bookService.GetListAsync();
            var model = books.Select(c => new BookDisplayModel(c)).ToList();
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var categories = await bookService.GetCategoriesAsync();
            if (categories != null)
            {
                var model = new BookEditModel(new Domain.Entities.Book(), categories.ToList());
                return View(model);
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Create(BookEditModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book();
                book.ImageUrl = model.ImageUrl;
                book.Price = model.Price;
                book.AvailableAmount = model.AvailableAmount;
                book.BookCategoryId = model.BookCategoryId;
                book.ShortDescription = model.ShortDescription;
                book.Title = model.Title;

                bookService.Add(book);
                return RedirectToAction("Index", "products");
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var book = await bookService.GetByIdAsync(id);
            var categories = await bookService.GetCategoriesAsync();
            if (book != null && categories != null)
            {
                var model = new BookEditModel(book, categories.ToList());
                return View(model);
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BookEditModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id > 0)
                {
                    var book = await bookService.GetByIdAsync(model.Id);
                    if (book != null)
                    {
                        book.ImageUrl = model.ImageUrl;
                        book.Price = model.Price;
                        book.AvailableAmount = model.AvailableAmount;
                        book.BookCategoryId = model.BookCategoryId;
                        book.ShortDescription = model.ShortDescription;
                        book.Title = model.Title;

                        bookService.Update(book);
                        return RedirectToAction("Index", "products");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await bookService.DeleteAsync(id);
            return RedirectToAction("Index", "products");
        }
    }
}