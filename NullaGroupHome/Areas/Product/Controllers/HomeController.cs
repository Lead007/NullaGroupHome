using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using NullaGroupHome.Areas.Product.ViewModel;
using NullaGroupHome.Models;

namespace NullaGroupHome.Areas.Product.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModInfoEntities _modInfoDb = new ModInfoEntities();
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = View("ExceptionPage", new ProductExceptionInfo(filterContext.Exception));
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }

        // GET: Product/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download(string modname)
        {
            if (string.IsNullOrEmpty(modname) || !Directory.Exists(Server.MapPath("~/Areas/Product/Files") + $"\\{modname}"))
            {
                throw new ModInexistenceException(modname);
            }
            var model =
                Directory.GetDirectories(Server.MapPath($"/Areas/Product/Files/{modname}"))
                    .Select(dire => new DownloadGameVersion(Server, _modInfoDb, modname, Path.GetFileName(dire)));
            return View(model);
        }

        public ActionResult Image(string modname)
        {
            if (string.IsNullOrEmpty(modname) || _modInfoDb.ModNames.All(mn => mn.Name != modname))
            {
                throw new ModInexistenceException(modname);
            }
            IEnumerable<ModImage> model = _modInfoDb.ModImages.Where(mi => mi.ModName.Name == modname).ToList();
            model = model.Skip(1);
            return View(model);
        }

        public ActionResult GetImage(int id)
        {
            return new FileContentResult(_modInfoDb.ModImages.SingleOrDefault(mi => mi.Id == id).Image, "image/jpeg");
        }

        public ActionResult ExceptionPage()
        {
            return View();
        }

        public ActionResult UploadModImage()
        {
            return View(_modInfoDb.ModImages.Select(mi => mi.ModName.Name).Distinct());
        }

        [HttpPost]
        public ActionResult ModImageUploader(FormCollection form)
        {
            var modname = form["modname"];
            var mi = new ModImage
            {
                ModId = _modInfoDb.ModNames.SingleOrDefault(mn => mn.Name == modname).Id,
                Uploader = form["uploader"],
                UploadDate = DateTime.Now,
                Information = form["information"],
                Image = Request.Files["image"].InputStream.GetBytes()
            };
            _modInfoDb.ModImages.Add(mi);
            _modInfoDb.SaveChanges();
            return UploadSuccess(modname);
        }

        public ActionResult UploadSuccess(string modname)
        {
            return View();
        }
    }
}