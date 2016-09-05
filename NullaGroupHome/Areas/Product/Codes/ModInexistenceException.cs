using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    /// <summary>mod不存在的异常</summary>
    public class ModInexistenceException : Exception
    {
        public ModInexistenceException() : base() { }
        public ModInexistenceException(string modname) : base($"找不到名为\"{modname}\"的mod。") { }

    }
}