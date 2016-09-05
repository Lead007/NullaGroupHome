using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    public struct ProductExceptionInfo
    {
        public Exception PageException { get; }

        public ProductExceptionInfo(Exception pageException)
        {
            PageException = pageException;
        }
    }
}