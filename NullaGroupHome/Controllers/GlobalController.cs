using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Controllers
{
    public class GlobalController : Controller
    {
        // GET: Global
        public string Index()
        {
            return string.Empty;
        }

        //GET: Global/MembersCount
        public string MembersCount()
        {
            return ConstFields.MembersCount.ToString();
        }
    }
}