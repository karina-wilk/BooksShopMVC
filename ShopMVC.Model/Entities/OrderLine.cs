using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerBook { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
