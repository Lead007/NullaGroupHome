using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        //GET: About/Members
        public ActionResult Members()
        {
            return View();
        }

        //GET: /About/Introduction
        public ActionResult Introduction(string name)
        {
            return View();
        }

        //GET: About/Contact
        public ActionResult Contact()
        {
            return View();
        }

        //GET: About/EmotionIcon
        public ActionResult EmotionIcon()
        {
            return View();
        }
    }
}