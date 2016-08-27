using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    /// <summary>和日期处理有关的函数的静态类</summary>
    public static class DateTimeHelper
    {
        /// <summary>将8位字符串转化为日期对象</summary>
        /// <param name="date">8位字符串表示的日期</param>
        /// <returns>日期对象</returns>
        public static DateTime ParseDateTime(string date)
            => new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2)));

        /// <summary>在8位字符串日期的年月、月日之间插入'-'</summary>
        /// <param name="date">8位字符串日期</param>
        /// <returns>转化后的字符串</returns>
        public static string ToString(string date)
        {
            var dateNew = date.Insert(6, "-");
            return dateNew.Insert(4, "-");
        }
    }
}