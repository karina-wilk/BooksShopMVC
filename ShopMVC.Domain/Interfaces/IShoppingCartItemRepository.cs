using ShopMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Interfaces
{
    public interface IShoppingCartItemRepository
    {
        Task<IEnumerable<ShoppingCartItem>> GetList(string userId);
        Task<ShoppingCartItem> GetById(int id);
        void Update(ShoppingCartItem item);
        Task Delete(int id);
        void Delete(ShoppingCartItem item);
        void Add(ShoppingCartItem item);
        Task<ShoppingCartItem> GetByBookIdAndUserId(int bookId, string userId);
        Task Save();
    }
}
