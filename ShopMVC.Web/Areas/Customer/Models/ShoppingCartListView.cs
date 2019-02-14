using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Web.Areas.Customer.Models
{
    public class ShoppingCartListView
    {
        public List<ShoppingCartDetailView> ShoppingCartItems { get; set; }
        public decimal TotalPrice => ShoppingCartItems.Sum(c => c.Price);

        public ShoppingCartListView()
        {
            ShoppingCartItems = new List<ShoppingCartDetailView>();
        }
    }
}