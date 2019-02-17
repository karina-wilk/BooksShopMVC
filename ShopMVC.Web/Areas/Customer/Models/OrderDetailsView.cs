using ShopMVC.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMVC.Web.Areas.Customer.Models
{
    public class OrderDetailsView
    {
        public int Id { get; set; }
        [Display(Name = "FirstName", ResourceType = typeof(LabelStrings))]
        public string FirstName { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(LabelStrings))]
        public string LastName { get; set; }
        [Display(Name = "StreetFull", ResourceType = typeof(LabelStrings))]
        public string Street { get; set; }
        [Display(Name = "City", ResourceType = typeof(LabelStrings))]
        public string City { get; set; }
        [Display(Name = "ZipCode", ResourceType = typeof(LabelStrings))]
        public string ZipCode { get; set; }
        [Display(Name = "Country", ResourceType = typeof(LabelStrings))]
        public string Country { get; set; }
        [Display(Name = "PhoneNumber", ResourceType = typeof(LabelStrings))]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email", ResourceType = typeof(LabelStrings))]
        public string Email { get; set; }

        public string UserId { get; set; }
    }
}