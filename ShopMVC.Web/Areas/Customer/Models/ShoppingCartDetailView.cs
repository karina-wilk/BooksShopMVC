using ShopMVC.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.Customer.Models
{
    public class ShoppingCartDetailView
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [Display(Name = "BookTitle", ResourceType = typeof(LabelStrings))]
        public string BookTitle { get; set; }
        [Display(Name = "BookPrice", ResourceType = typeof(LabelStrings))]
        public decimal BookPrice { get; set; }
        [Display(Name = "Quantity", ResourceType = typeof(LabelStrings))]
        public int Quantity { get; set; }
        public List<SelectListItem> Quantities { get; set; }
        [Display(Name = "SummaryPrice", ResourceType = typeof(LabelStrings))]
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