using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Areas.Product.Controllers
{
    public class HomeController : Controller
    {
        // GET: Product/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download(string modname)
        {
            return View();
        }

        public ActionResult Image(string modname)
        {
            return View();
        }
    }
}