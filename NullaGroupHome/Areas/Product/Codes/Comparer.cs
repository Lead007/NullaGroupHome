using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NullaGroupHome;

namespace NullaGroupHome.Areas.Product
{
    /// <summary>用于比较两个文件名（含后缀名）的版本先后</summary>
    public class FileVersionComparer : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            return new ModFile(FileHelper.GetFullFileName(x)).CompareTo(new ModFile(FileHelper.GetFullFileName(y)));
        }
    }
}