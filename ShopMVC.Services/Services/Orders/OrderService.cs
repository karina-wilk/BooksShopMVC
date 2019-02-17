using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.UnitOfWork;
using ShopMVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Model.Entities;

namespace ShopMVC.Services.Orders
{
    public class OrderService : IOrderService
    {
        private OrderUnitOfWork OrderUoW = new OrderUnitOfWork();

        public async Task<Order> Add(Order order, List<OrderLine> orderLines, string userId)
        {
            order.DateCreated = DateTime.Now;
            order.OrderLines = orderLines;
            order.OrderTotal = orderLines.Sum(c => c.Quantity * c.PricePerBook);
            order.UserId = userId;

            return await OrderUoW.OrderRepo.AddOrderAndCleanShoppingCart(order);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(string userId)
        {
            return await OrderUoW.ShoppingCartItemRepo.GetList(userId);
        }

        public void Dispose()
        {
            OrderUoW.Dispose();
        }
    }
}
