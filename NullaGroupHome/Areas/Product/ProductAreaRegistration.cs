using System.Web.Mvc;

namespace NullaGroupHome.Areas.Product
{
    public class ProductAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Product";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //默认路由
            context.MapRoute(
                name: "Product_default",
                url: "Product/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, area = "Product" },
                namespaces: new[] { "NullaGroupHome.Areas.Product.Controllers" }
            );


        }
    }
}