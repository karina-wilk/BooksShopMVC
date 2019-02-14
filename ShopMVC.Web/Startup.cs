using Microsoft.Owin;
using Owin;
using ShopMVC.Domain.Identity;

[assembly: OwinStartupAttribute(typeof(ShopMVC.Web.Startup))]
namespace ShopMVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //Rest of code is removed for brevity

            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            //Rest of code is removed for brevity

        }
    }
}
