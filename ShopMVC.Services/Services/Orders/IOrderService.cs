using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Services.Orders
{
    public interface IOrderService
    {
        //Task<Order> Add(Order order, List<OrderLine> orderLines, string userId);
        Task<Order> Add(Order order, List<OrderLine> orderLines, string userId);
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(string userId);
    }
}
