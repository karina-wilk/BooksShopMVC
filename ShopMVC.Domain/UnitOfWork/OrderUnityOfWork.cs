using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.UnitOfWork
{
    public class OrderUnitOfWork: IDisposable
    {
        public readonly ShopDBContext context = new ShopDBContext();
        private IOrderRepository orderRepository;
        private IShoppingCartItemRepository shoppingCartRepository;

        public IOrderRepository OrderRepo
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(context);
                }
                return orderRepository;
            }
        }

        public IShoppingCartItemRepository ShoppingCartItemRepo
        {
            get
            {
                if (this.shoppingCartRepository == null)
                {
                    this.shoppingCartRepository = new ShoppingCarItemRepository(context);
                }
                return shoppingCartRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
