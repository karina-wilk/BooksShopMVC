namespace ShopMVC.Domain.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ShopMVC.Domain.DAL;
    using ShopMVC.Domain.Entities;
    using ShopMVC.Model.Entities;
    using ShopMVC.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopMVC.Domain.DAL.ShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopMVC.Domain.DAL.ShopDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //  This method will be called after migrating to the latest version.

            var catSciFi = new BookCategory { Name = "Science-fiction" };
            var catCrimeStory = new BookCategory { Name = "Crime story" };
            var catLoveStory = new BookCategory { Name = "Love story" };
            var catFairyTales = new BookCategory { Name = "Fairy tales" };
            var catAdventure = new BookCategory { Name = "Adventure" };

            context.Categories.Add(catSciFi);
            context.Categories.Add(catCrimeStory);
            context.Categories.Add(catLoveStory);
            context.Categories.Add(catFairyTales);
            context.Categories.Add(catAdventure);

            context.Books.Add(new Book() { Category = catSciFi, Price = 50, ShortDescription = "", Title = "The Lord of the Rings", AvailableAmount=4 });
            context.Books.Add(new Book() { Category = catSciFi, Price = 50, ShortDescription = "", Title = "The Hobbit", AvailableAmount = 20 });

            context.SaveChanges();

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopDBContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopDBContext()));
            var claim = new IdentityUserClaim()
            {
                ClaimType = "Basic",
                ClaimValue = "CanSendOrder"
            };
            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "taiseer.joudeh@gmail.com",
                EmailConfirmed = true,
                FirstName = "Karina",
                //LastName = "Joudeh",
                //Level = 1,
                //JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "MySuperP@ss!");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Customer" });
                roleManager.Create(new IdentityRole { Name = "Seller" });
            }

            var adminUser = manager.FindByName("SuperPowerUser");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "Seller" });


            var userCar = new ApplicationUser()
            {
                UserName = "car",
                Email = "car@gmail.com",
                EmailConfirmed = true,
                FirstName = "Karina",
                //LastName = "Joudeh",
                //Level = 1,
                //JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(userCar, "Admin123");
            var adminCarUser = manager.FindByName("car");
            manager.AddToRoles(adminCarUser.Id, new string[] { "Admin", "Seller" });

            //Customer
            var userCust = new ApplicationUser()
            {
                UserName = "jan",
                Email = "jan@gmail.com",
                EmailConfirmed = true,
                FirstName = "Jan",
                //LastName = "Joudeh",
                //Level = 1,
                //JoinDate = DateTime.Now.AddYears(-3)
            };
            manager.Create(userCust, "Admin123");
            var janUser = manager.FindByName("jan");
            manager.AddToRoles(janUser.Id, new string[] { "Customer"});
        }
    }
}
