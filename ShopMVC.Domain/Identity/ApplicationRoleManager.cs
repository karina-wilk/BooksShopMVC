using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ShopMVC.Domain.DAL;
using ShopMVC.Web.Models;


namespace ShopMVC.Domain.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationIdentityRole, int>
    {
        public ApplicationRoleManager(IntRoleStore roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var manager = new ApplicationRoleManager(new IntRoleStore(context.Get<ShopDBContext>()));
            return manager;
        }
    }
}
