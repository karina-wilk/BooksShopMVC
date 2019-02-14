using Microsoft.AspNet.Identity.Owin;
using ShopMVC.Domain;
using ShopMVC.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Web.Controllers
{
    public class AuthController : Controller
    {
        private ApplicationRoleManager _AppRoleManager = null;

        protected ApplicationRoleManager AppRoleManager
        {
            get => _AppRoleManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
           
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
    }
}