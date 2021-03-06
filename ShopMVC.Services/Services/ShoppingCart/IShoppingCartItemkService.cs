﻿using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.ShoppingCart
{
    public interface IShoppingCartItemService : IDisposable
    {
        Task<bool> AddBookToCart(string userId, int bookId);
        Task<bool> ChangeQuantity(int itemId, int newQuantity);

        Task<IEnumerable<ShoppingCartItem>> GetList(string userId);
        void Update(ShoppingCartItem item);
        Task Delete(int id);
        Task<ShoppingCartItem> GetByBookIdAndUserId(int bookId, string userId);
    }
}
