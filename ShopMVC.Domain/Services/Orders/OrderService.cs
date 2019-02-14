using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Services.Orders
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

            using (var dbContextTransaction = OrderUoW.context.Database.BeginTransaction())
            {
                try
                {
                    OrderUoW.OrderRepo.Add(order);

                    foreach(var item in await OrderUoW.ShoppingCartItemRepo.GetList(userId))
                    {
                        OrderUoW.ShoppingCartItemRepo.Delete(item);
                    }

                    OrderUoW.Save();

                    dbContextTransaction.Commit();

                    return order;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return null;
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(string userId)
        {
            return await OrderUoW.ShoppingCartItemRepo.GetList(userId);
        }
    }
}
