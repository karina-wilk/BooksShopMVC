using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Filters
{
    public class ExceptionLoggerFilter2 : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //Saving exception (filterContext.Exception) with some log library (ex. NLog).

            base.OnException(filterContext);
        }
    }
}