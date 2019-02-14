using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly ShopDBContext context;

        public BookCategoryRepository(ShopDBContext context)
        {
            this.context = context;
        }
        
        public async Task<IEnumerable<BookCategory>> GetList()
        {
            return await context.Categories.ToListAsync();
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
