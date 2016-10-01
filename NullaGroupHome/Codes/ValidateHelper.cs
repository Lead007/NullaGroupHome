using System.Linq;
using System.Web;

namespace NullaGroupHome
{
    public static class ValidateHelper
    {
        /// <summary>
        /// 是否已验证密码
        /// </summary>
        /// <param name="request">Response对象</param>
        /// <returns>是否已验证密码</returns>
        public static bool HasValidatedPassword(this HttpRequestBase request)
        {
            return request.Cookies.Get("password")?.Value == true.ToString().ToLower();
        }
    }
}