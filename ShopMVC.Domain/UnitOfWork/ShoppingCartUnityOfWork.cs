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
    public class ShoppingCartUnityOfWork : IDisposable
    {
        public readonly ShopDBContext context = new ShopDBContext();
        private IBookRepository bookRepository;
        private IShoppingCartItemRepository shoppingCartItemRepository;

        public IBookRepository BookRepo
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(context);
                }
                return bookRepository;
            }
        }

        public IShoppingCartItemRepository ShoppingCartItemRepo
        {
            get
            {
                if (this.shoppingCartItemRepository == null)
                {
                    this.shoppingCartItemRepository = new ShoppingCarItemRepository(context);
                }
                return shoppingCartItemRepository;
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
