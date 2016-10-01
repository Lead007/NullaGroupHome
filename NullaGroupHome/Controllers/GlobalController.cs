using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Controllers
{
    /// <summary>
    /// 全局控制器，一般用于全局变量，以及一些ajax get算法
    /// </summary>
    public class GlobalController : Controller
    {
        // GET: Global
        public string Index()
        {
            return string.Empty;
        }

        public string MembersCount()
        {
            return ConstFields.MembersCount.ToString();
        }


        private static readonly byte[] Password = { 62, 233, 135, 107, 1, 21, 94, 28, 229, 5, 150, 239, 160, 174, 84, 226 };
        public string PasswordValidater(string password)
        {
            var input = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(password));
            if (input.Length != Password.Length) return false.ToString().ToLower();
            if (input.Where((t, i) => Password[i] != t).Any()) return false.ToString().ToLower();
            var cookie = new HttpCookie("password")
            {
                Value = true.ToString().ToLower(),
                Expires = DateTime.Now + new TimeSpan(1, 0, 0, 0)
            };
            Response.Cookies.Add(cookie);
            return true.ToString().ToLower();
        }
    }
}