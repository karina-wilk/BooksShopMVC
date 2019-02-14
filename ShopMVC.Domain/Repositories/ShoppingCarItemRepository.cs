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
    internal class ShoppingCarItemRepository : IShoppingCartItemRepository
    {
        private readonly ShopDBContext context;

        public ShoppingCarItemRepository(ShopDBContext context)
        {
            this.context = context;
        }

        public void Add(ShoppingCartItem item)
        {
            context.ShoppingCartItems.Add(item);
        }

        public async Task Delete(int id)
        {
            var entity = await context.ShoppingCartItems.FindAsync(id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public void Delete(ShoppingCartItem entity)
        {
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public async Task<ShoppingCartItem> GetByBookIdAndUserId(int bookId, string userId)
        {
            return await context.ShoppingCartItems.FirstOrDefaultAsync(e => e.BookId == bookId && e.UserId == userId);
        }

        public async Task<ShoppingCartItem> GetById(int id)
        {
            return await context.ShoppingCartItems.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetList()
        {
            return await context.ShoppingCartItems.Include(x => x.Book).ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetList(string userId)
        {
            return await context.ShoppingCartItems
                .Include(x => x.Book)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public void Update(ShoppingCartItem item)
        {
            var entity = context.ShoppingCartItems.Find(item.Id);
            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(item);
            }
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
