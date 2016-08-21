using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome
{
    public static class ConstFields
    {
        /// <summary>成员总数</summary>
        public const int MembersCount = 72;

        /// <summary>建立时间</summary>
        public static DateTime BuildTime { get; } = new DateTime(2014, 12, 14);

        /// <summary>组长</summary>
        public static string Leader { get; } = Administrator.小鸟小姐.ToString();
    }
}