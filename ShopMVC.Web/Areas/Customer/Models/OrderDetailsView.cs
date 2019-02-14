using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Web.Areas.Customer.Models
{
    public class OrderDetailsView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string UserId { get; set; }
    }
}