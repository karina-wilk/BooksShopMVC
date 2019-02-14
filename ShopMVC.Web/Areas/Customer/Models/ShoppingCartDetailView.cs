using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.Customer.Models
{
    public class ShoppingCartDetailView
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public decimal BookPrice { get; set; }
        public int Quantity { get; set; }
        public List<SelectListItem> Quantities { get; set; }
        public decimal Price => BookPrice * Quantity;

        public ShoppingCartDetailView()
        {
            Quantities = new List<SelectListItem>();

            for (int i = 1; i <= 10; i++)
            {
                Quantities.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
        }
    }
}