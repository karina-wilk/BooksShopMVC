using Microsoft.AspNet.Identity;
using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Identity;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using ShopMVC.Domain.Services;
using ShopMVC.Domain.Services.Orders;
using ShopMVC.Web.Areas.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public OrderController()
        {
            this.orderService = new OrderService();
        }

        // GET: Customer/Order
        public ActionResult Index()
        {
            var model = new OrderDetailsView();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(OrderDetailsView model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var orderLines = new List<OrderLine>();

                var shoppingCartItems = await orderService.GetShoppingCartItems(userId);
                foreach(var i in shoppingCartItems)
                {
                    orderLines.Add(new OrderLine
                    {
                        BookName = i.Book.Title,
                        PricePerBook = i.Book.Price,
                        Quantity = i.Quantity
                    });
                }

                var order = new Order();
                order.City = model.City;
                order.Country = model.Country;
                order.Email = model.Email;
                order.FirstName = model.FirstName;
                order.LastName = model.LastName;
                order.PhoneNumber = model.PhoneNumber;
                order.Street = model.Street;
                order.ZipCode = model.ZipCode;

                var result = orderService.Add(order, orderLines, userId);
                if (result != null)
                {
                    Session["ItemsInShoppingCart"] = 0;
                    TempData["Message"] = "Order sent!";
                    return RedirectToAction("Index", "products");
                }
            }
            return View(model);
        }
    }
}