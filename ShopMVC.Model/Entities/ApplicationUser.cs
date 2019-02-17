using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShopMVC.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationIdentityRole : IdentityRole<int, IntUserRole>
    {
        public ApplicationIdentityRole() { }
        public ApplicationIdentityRole(string name) { Name = name; }
    }

    public class IntUserRole : IdentityUserRole<int> { }
    public class IntUserClaim : IdentityUserClaim<int> { }
    public class IntUserLogin : IdentityUserLogin<int> { }

    public class IntRoleStore : RoleStore<ApplicationIdentityRole, int, IntUserRole>
    {
        public IntRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}