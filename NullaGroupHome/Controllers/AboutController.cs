using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NullaGroupHome.Models;

namespace NullaGroupHome.Controllers
{
    public class AboutController : Controller
    {
        private readonly ModInfoEntities _modInfoDb = new ModInfoEntities();
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        //GET: About/Members
        public ActionResult Members()
        {
            return View();
        }

        //GET: /About/Introduction
        public ActionResult Introduction(string name)
        {
            return View();
        }

        //GET: About/Contact
        public ActionResult Contact()
        {
            return View();
        }

        //GET: About/EmotionIcon
        public ActionResult EmotionIcon()
        {
            return View(_modInfoDb.EmotionIcons);
        }

        public ActionResult GetEmotionTemplate(int id)
        {
            var ei = _modInfoDb.EmotionIcons.SingleOrDefault(e => e.Id == id);
            return new FileContentResult(ei.Template, ei.TemplateExtension == "jpg" ? "image/jpeg" : "image/gif");
        }

        public ActionResult GetEmotionIcon(int id)
        {
            var ei = _modInfoDb.EmotionIcons.SingleOrDefault(e => e.Id == id);
            return new FileContentResult(ei.Emotion, "image/jpeg");
        }

        //GET: About/EmotionIconZipDownload
        public ActionResult EmotionIconZipDownload()
        {
            //生成压缩包
            byte[] packageByte;
            using (var memory = new MemoryStream())
            {
                using (var package = Package.Open(memory, FileMode.Create))
                {
                    var info = package.CreatePart(new Uri("/Readme.txt", UriKind.Relative), "");
                    var infobytes = Encoding.UTF8.GetBytes("本表情包由小鸟小姐版权所有，请勿随意转载！\n请无视压缩包内的[Content_Types].xml文件。");
                    info.GetStream().Write(infobytes, 0, infobytes.Length);
                    var i = 1;
                    foreach (var ei in _modInfoDb.EmotionIcons)
                    {
                        if (ei.Template != null)
                        {
                            var part = package.CreatePart(new Uri($"/Template/{i}.{ei.TemplateExtension}", UriKind.Relative), "");
                            var bytes = ei.Template;
                            part.GetStream().Write(bytes, 0, bytes.Length);
                        }
                        var part2 = package.CreatePart(new Uri($"/Emotion/{i}.jpg", UriKind.Relative), "");
                        var bytes2 = ei.Emotion;
                        part2.GetStream().Write(bytes2, 0, bytes2.Length);
                        i++;
                    }
                }
                packageByte = memory.ToArray();
            }
            return File(packageByte, MediaTypeNames.Application.Zip, "表情包.zip");
        }

        public ActionResult UploadEmotionIcon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmotionIconUploader(FormCollection form)
        {
            var ei = new EmotionIcon
            {
                Template = this.Request.Files["template"].InputStream.GetBytes(),
                TemplateExtension = Path.GetExtension(this.Request.Files["template"]?.FileName)?.TrimStart('.'),
                Emotion = this.Request.Files["emotion"].InputStream.GetBytes()
            };
            _modInfoDb.EmotionIcons.Add(ei);
            _modInfoDb.SaveChanges();
            return View("UploadSuccess");
            //return Content($"{ei.Template.Length} {ei.Emotion.Length}");
        }
    }
}