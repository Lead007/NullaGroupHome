using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NullaGroupHome.Controllers
{
    public class AboutController : Controller
    {
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
            return View();
        }

        //GET: About/EmotionIconZipDownload
        [HttpGet]
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
                    foreach (var file in Directory.GetFiles(this.Server.MapPath("/Content/_MyImages/About/Emotions/Emotion")))
                    {
                        var part = package.CreatePart(new Uri($"/Emotion/{Path.GetFileName(file)}", UriKind.Relative), "");
                        var bytes = System.IO.File.ReadAllBytes(file);
                        part.GetStream().Write(bytes, 0, bytes.Length);
                    }
                    foreach (var file in Directory.GetFiles(this.Server.MapPath("/Content/_MyImages/About/Emotions/Template")))
                    {
                        var part = package.CreatePart(new Uri($"/Template/{Path.GetFileName(file)}", UriKind.Relative), "");
                        var bytes = System.IO.File.ReadAllBytes(file);
                        part.GetStream().Write(bytes, 0, bytes.Length);
                    }
                }
                packageByte = memory.ToArray();
            }
            return File(packageByte, MediaTypeNames.Application.Zip, "表情包.zip");
        }
    }
}