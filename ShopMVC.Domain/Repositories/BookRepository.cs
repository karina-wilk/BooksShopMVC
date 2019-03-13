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
    internal class BookRepository : IBookRepository
    {
        private readonly ShopDBContext context;

        public BookRepository(ShopDBContext context)
        {
            this.context = context;
        }

        public void Add(Book item)
        {
            context.Books.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Books.FindAsync(id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await context.Books.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Book> GetByIdFullDataAsync(int id)
        {
            return await context.Books.Include(x => x.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Book>> GetListAsync()
        {
            return await context.Books.Include(x => x.Category).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetListOfBestsellingAsync()
        {
            var query = (from item in context.OrderLines
                         group item.Quantity by item.Book into X
                         orderby X.Sum() descending
                         select X.Key);
            return await query.Take(8).ToListAsync(); 
        }

        public void Update(Book item)
        {
            var entity = context.Books.Find(item.Id);
            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(item);
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
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
