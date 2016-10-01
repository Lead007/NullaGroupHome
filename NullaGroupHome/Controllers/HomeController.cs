using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Controllers
{
    public class HomeController : Controller
    {
        //GET: /
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Home/NotFound
        public ActionResult NotFound()
        {
            return View();
        }

        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="targetarea">目标区域</param>
        /// <param name="targetcontroller">目标控制器</param>
        /// <param name="targetaction">目标行为</param>
        /// <returns></returns>
        public ActionResult ValidatePassword(string targetarea, string targetcontroller, string targetaction)
        {
            return View();
        }
    }
}