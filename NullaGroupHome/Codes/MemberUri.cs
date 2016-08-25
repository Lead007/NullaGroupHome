using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NullaGroupHome
{
    /// <summary>包含自动生成链接到成员介绍的Uri的方法的静态类</summary>
    public static class MemberUri
    {
        public static MvcHtmlString GetMemberUri(HtmlHelper html,string memberName)
        {
            return html.ActionLink(memberName, "Introduction", "About", new { name = memberName }, null);
        }
        public static MvcHtmlString GetMemberUri(HtmlHelper html, Administrator member)
        {
            return html.ActionLink(member.ToString(), "Introduction", "About", new { name = member.ToString() }, null);
        }

        public static string GetMemberUriString(HtmlHelper html, string memberName)
        {
            return string.Format("<a href=\"/About/Introduction?name={0}\">{0}</a>", memberName);
        }

        public static string GetMemberUriString(HtmlHelper html, Administrator member)
        {
            return GetMemberUriString(html, member.ToString());
        }
    }
}