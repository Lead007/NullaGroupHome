using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace NullaGroupHome
{
    /// <summary>和文件处理有关的函数的静态类</summary>
    public static class FileHelper
    {
        /// <summary>转化文件大小</summary>
        /// <param name="file">文件对象</param>
        /// <returns>转换后大小</returns>
        public static string GetFileSize(this FileInfo file)
        {
            decimal byteCount = file.Length;
            if (byteCount < 1024) return byteCount + "B";
            var fileSize = (byteCount) / 1024;
            return fileSize < 1024 ? GetRound(fileSize) + "KB" : GetRound(fileSize/1024) + "MB";
        }

        private static string GetRound(decimal num)
        {
            if (num >= 100) return ((int) Math.Round(num)).ToString();
            return num.ToString(num >= 10 ? "F1" : "F");
        }
    }
}