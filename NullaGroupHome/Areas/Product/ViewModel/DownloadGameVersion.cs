using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace NullaGroupHome.Areas.Product.ViewModel
{
    public class DownloadGameVersion
    {
        public string GameVersion { get; }
        public string Preposition { get; set; }
        public List<Tuple<FileInfo, ModFile>> Files { get; }

        public DownloadGameVersion(HttpServerUtilityBase server, string modName, string gameVersion)
        {
            GameVersion = gameVersion;
            var files = Directory.GetFiles(server.MapPath($"/Areas/Product/Files/{modName}/{gameVersion}"));
            var xmlPath = files.SingleOrDefault(path => Path.GetFileName(path) == "VersionInfo.xml");
            if (xmlPath == null)
            {
                Preposition = null;
            }
            else
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlPath);
                Preposition = (xmlDocument.SelectSingleNode("/version-info/preposition") as XmlElement)?.GetAttribute("name");
                if (Preposition != null)
                {
                    Files =
                        files.Where(path => Path.GetExtension(path) == ".jar")
                            .Select(path =>
                                new Tuple<FileInfo, ModFile>(new FileInfo(path),
                                    new ModFileWithPreposition(Path.GetFileName(path), xmlDocument)))
                            .ToList();
                }
            }
            if (Preposition == null)
            {
                Files =
                    files.Where(path => Path.GetExtension(path) == ".jar")
                        .Select(path =>
                            new Tuple<FileInfo, ModFile>(new FileInfo(path), new ModFile(Path.GetFileName(path))))
                        .ToList();
            }
        }
    }
}