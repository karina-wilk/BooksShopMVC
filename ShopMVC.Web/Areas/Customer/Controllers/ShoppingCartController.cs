using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShopMVC.Domain;
using ShopMVC.Web.Areas.Customer.Models;
using System.Threading.Tasks;
using ShopMVC.Services.Books;
using ShopMVC.Domain.ShoppingCart;
using ShopMVC.Services.ShoppingCart;

namespace ShopMVC.Web.Areas.Customer.Controllers
{
    public class ShoppingCartController : Controller
    {
        IBookService bookService;
        IShoppingCartItemService shoppingCartService;

        public ShoppingCartController(IShoppingCartItemService shoppingCartService, IBookService bookService)
        {
            this.shoppingCartService = shoppingCartService;
            this.bookService = bookService;
        }

        public ShoppingCartController()
        {
            this.shoppingCartService = new ShoppingCartItemService();
            this.bookService = new BookService();
        }

        // GET: ShoppingCart
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var model = new ShoppingCartListView();

            var shoppingCartItems = await shoppingCartService.GetList(userId);
            if (shoppingCartItems.Count() > 0)
            {
                foreach (var item in shoppingCartItems)
                {
                    var itemInCart = new ShoppingCartDetailView()
                    {
                        BookId = item.BookId,
                        BookPrice = item.Book.Price,
                        BookTitle = item.Book.Title,
                        Id = item.Id,
                        Quantity = item.Quantity
                    };
                    itemInCart.Quantities.Where(c => c.Value == item.Quantity.ToString()).First().Selected = true;

                    model.ShoppingCartItems.Add(itemInCart);
                }
            }
            else
            {
                ViewBag.Message = "Your shopping cart is empty!";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddToShoppingCart(int bookId)
        {
            var userId = User.Identity.GetUserId();
            var result = await shoppingCartService.AddBookToCart(userId, bookId);
            if(!result)
            {
                TempData["Message"] = "There is not enough products in our store!";
                return RedirectToAction("Index");
            }

            var shoppingCartItems = await shoppingCartService.GetList(userId);
            Session["ItemsInShoppingCart"] = shoppingCartItems?.Count();
            return RedirectToAction("Index"); //Redirect to shopping cart.
        }

        [HttpPost]
        public async Task<ActionResult> ChangeAmount(int itemId, [Bind(Include = "Quantity")]ShoppingCartDetailView item)
        {
            var result = await shoppingCartService.ChangeQuantity(itemId, item.Quantity);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ShoppingCartDetailView item)
        {
            await shoppingCartService.Delete(item.Id);
           
            //Updating shopping cart widget.
            var userId = User.Identity.GetUserId();
            var shoppingCartItems = await shoppingCartService.GetList(userId);
            Session["ItemsInShoppingCart"] = shoppingCartItems?.Count();

            return RedirectToAction("Index");
        }
    }
}
