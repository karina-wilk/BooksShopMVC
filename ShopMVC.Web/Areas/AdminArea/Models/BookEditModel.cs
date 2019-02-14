using ShopMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.AdminArea.Models
{
    public class BookEditModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int AvailableAmount { get; set; }
        public string ImageUrl { get; set; }
        public int BookCategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public BookEditModel()
        {
            Categories = new List<SelectListItem>();
        }

        public BookEditModel(Book book, List<BookCategory> categories)
        {
            Id = book.Id;
            Title = book.Title;
            ShortDescription = book.ShortDescription;
            Price = book.Price;
            AvailableAmount = book.AvailableAmount;
            ImageUrl = book.ImageUrl;
            BookCategoryId = book.BookCategoryId;
            Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem());
            foreach (var cat in categories)
            {
                Categories.Add(new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString(), Selected = cat.Id == book.BookCategoryId });
            }
        }
    }
}