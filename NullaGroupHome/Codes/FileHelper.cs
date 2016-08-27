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
        /// <summary>获取文件名（不含后缀名）</summary>
        /// <param name="file">文件的完全限定名</param>
        /// <returns>不含后缀的文件名</returns>
        public static string GetFileName(string file)
        {
            var fileName = GetFullFileName(file);
            return fileName.Substring(0, fileName.LastIndexOf('.'));
        }

        /// <summary>获取文件名（含后缀名）（亦可获取文件夹名）</summary>
        /// <param name="file">文件的完全限定名</param>
        /// <returns>含后缀的文件名</returns>
        public static string GetFullFileName(string file) => file.Substring(file.LastIndexOf('\\') + 1);

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