using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Filters
{
    public class ExceptionLoggerFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Saving log with some library (ex. NLog).
            Log(filterContext.Exception);
        }

        private void Log(Exception exception)
        {
            //log exception here..
        }
    }
}