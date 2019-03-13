using ShopMVC.Services.Books;
using ShopMVC.Web.Areas.AdminArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public HomeController()
        {
            this.bookService = new BookService();
        }

        public async Task<ActionResult> Index()
        {
            var model = new List<BookDisplayModel>();
            var books = await bookService.GetListOfBestsellingAsync();
            if (books != null)
            {
                model = books.Select(c => new BookDisplayModel(c)).ToList();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}