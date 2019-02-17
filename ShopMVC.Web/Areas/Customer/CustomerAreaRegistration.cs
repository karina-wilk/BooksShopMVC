using System.Web.Mvc;

namespace ShopMVC.Web.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Customer_Books_List",
               "BooksList/{action}/{id}",
               new { action = "Index", Controller = "Products", id = UrlParameter.Optional }
           );
            //Wtedy zadziała:
            //http://localhost/bookshop/BooksList/details/6
            //http://localhost/bookshop/BooksList

            context.MapRoute(
                "Customer_default",
                "Shop/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}