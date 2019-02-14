using Microsoft.AspNet.Identity.EntityFramework;
using ShopMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.DAL
{
    public class ShopDBContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public ShopDBContext()
           : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public static ShopDBContext Create()
        {
            return new ShopDBContext();
        }
    }
}
