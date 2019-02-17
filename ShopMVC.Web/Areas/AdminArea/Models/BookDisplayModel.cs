using ShopMVC.Domain.Entities;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Areas.AdminArea.Models
{
    public class BookDisplayModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int AvailableAmount { get; set; }
        public string ImageUrl { get; set; }
        public int BookCategoryId { get; set; }
        public string BookCategoryName { get; set; }

        public BookDisplayModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            ShortDescription = book.ShortDescription;
            Price = book.Price;
            AvailableAmount = book.AvailableAmount;
            ImageUrl = book.ImageUrl;
            BookCategoryId = book.BookCategoryId;
            BookCategoryName = book.Category?.Name;
        }
    }
}