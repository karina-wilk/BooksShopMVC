using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal OrderTotal { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }

        public Order() => OrderLines = new List<OrderLine>(); 
    }
}
