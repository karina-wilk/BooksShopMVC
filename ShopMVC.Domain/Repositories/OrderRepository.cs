using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDBContext context;

        public OrderRepository(ShopDBContext context)
        {
            this.context = context;
        }

        public void Add(Order item)
        {
            context.Orders.Add(item);
        }

        public async Task<Order> AddOrderAndCleanShoppingCart(Order order)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    this.Add(order);

                    foreach (var item in context.ShoppingCartItems.Where(c => c.UserId == order.UserId))
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    await context.SaveChangesAsync();

                    dbContextTransaction.Commit();

                    return order;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public void Submit()
        {
            context.SaveChanges();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders.Include(x => x.OrderLines).FirstOrDefaultAsync(e => e.Id == id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
