using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.ShoppingCart;
using ShopMVC.Domain.UnitOfWork;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopMVC.Services.ShoppingCart
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private ShoppingCartUnityOfWork ShoppingCartUoW = new ShoppingCartUnityOfWork();

        public async Task<bool> AddBookToCart(string userId, int bookId)
        {
            var bookToAdd = await ShoppingCartUoW.BookRepo.GetByIdAsync(bookId);
            if (bookToAdd != null)
            {
                var existingItemInCart = await ShoppingCartUoW.ShoppingCartItemRepo.GetByBookIdAndUserId(bookId, userId);

                if (existingItemInCart != null)
                {
                    if (bookToAdd.AvailableAmount > 0)
                    {
                        existingItemInCart.Quantity++;
                        ShoppingCartUoW.ShoppingCartItemRepo.Update(existingItemInCart);
                        await ShoppingCartUoW.ShoppingCartItemRepo.Save();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (bookToAdd.AvailableAmount > 0)
                    {
                        var shoppingCartItem = new ShoppingCartItem
                        {
                            Book = bookToAdd,
                            BookId = bookToAdd.Id,
                            Quantity = 1,
                            UserId = userId
                        };
                        ShoppingCartUoW.ShoppingCartItemRepo.Add(shoppingCartItem);
                        await ShoppingCartUoW.ShoppingCartItemRepo.Save();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public async Task<bool> ChangeQuantity(int itemId, int newQuantity)
        {
            var shoppingCartItem = await ShoppingCartUoW.ShoppingCartItemRepo.GetById(itemId);
            if (shoppingCartItem != null)
            {
                shoppingCartItem.Quantity = newQuantity;
                ShoppingCartUoW.ShoppingCartItemRepo.Update(shoppingCartItem);
                await ShoppingCartUoW.ShoppingCartItemRepo.Save();
                return true;
            }
            return false;
        }

        public async Task Delete(int id)
        {
            await ShoppingCartUoW.ShoppingCartItemRepo.Delete(id);
            ShoppingCartUoW.Save();
        }

        public async Task<ShoppingCartItem> GetByBookIdAndUserId(int bookId, string userId)
        {
            return await ShoppingCartUoW.ShoppingCartItemRepo.GetByBookIdAndUserId(bookId, userId);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetList(string userId)
        {
            return await ShoppingCartUoW.ShoppingCartItemRepo.GetList(userId);
        }

        public void Update(ShoppingCartItem item)
        {
            ShoppingCartUoW.ShoppingCartItemRepo.Update(item);
            ShoppingCartUoW.Save();
        }
    }
}
