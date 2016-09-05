using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Areas.Product.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is ModInexistenceException)
            {
                filterContext.Result = View("ExceptionPage",new ProductExceptionInfo(filterContext.Exception));
                filterContext.ExceptionHandled = true;
            }
            base.OnException(filterContext);
        }

        // GET: Product/Home
        public ActionResult Index()
        {
            return View();
        }

        [HandleError(View = "ExceptionPage_Product", ExceptionType = typeof(Exception))]
        public ActionResult Download(string modname)
        {
            return View();
        }

        [HandleError(View = "ExceptionPage_Product", ExceptionType = typeof(Exception))]
        public ActionResult Image(string modname)
        {
            return View();
        }

        public ActionResult ExceptionPage()
        {
            return View();
        }
    }
}