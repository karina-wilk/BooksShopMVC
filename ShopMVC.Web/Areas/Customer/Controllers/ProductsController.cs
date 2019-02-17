using ShopMVC.Services.Books;
using ShopMVC.Web.Areas.AdminArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.Customer.Controllers
{
    [HandleError]
    [Route("/products")]
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

        // GET: Customer/Books
        //[OutputCache(Duration = 100)]
        public async Task<ActionResult> Index()
        {
            ViewBag.ActionTitle = "All books";
            var books = await bookService.GetListAsync();
            var model = books.Select(c => new BookDisplayModel(c)).ToList();
            return View(model);
        }

        // GET: Customer/Details
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.ActionTitle = "Book's details";
            var book = await bookService.GetByIdFullDataAsync(id);
            var model = new BookDisplayModel(book);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && bookService != null)
            {
                bookService.Dispose();
                bookService = null;
            }
            base.Dispose(disposing);
        }
    }
}