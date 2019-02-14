using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Services.Books
{
    public class BookUnityOfWork : IDisposable
    {
        public readonly ShopDBContext context = new ShopDBContext();
        private IBookRepository bookRepository;
        private IBookCategoryRepository bookCategoryRepository;

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

        public IBookCategoryRepository BookCategoryRepo
        {
            get
            {
                if (this.bookCategoryRepository == null)
                {
                    this.bookCategoryRepository = new BookCategoryRepository(context);
                }
                return bookCategoryRepository;
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
