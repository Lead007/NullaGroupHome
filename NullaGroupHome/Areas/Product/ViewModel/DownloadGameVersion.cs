using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using NullaGroupHome.Models;

namespace NullaGroupHome.Areas.Product.ViewModel
{
    /// <summary>
    /// 游戏版本
    /// </summary>
    public class DownloadGameVersion
    {
        /// <summary>
        /// 游戏版本
        /// </summary>
        public string GameVersion { get; }

        /// <summary>
        /// 前置mod名
        /// </summary>
        public string Preposition { get; }

        /// <summary>
        /// 文件列表
        /// </summary>
        public List<Tuple<FileInfo, ModFile>> Files { get; }

        public DownloadGameVersion(HttpServerUtilityBase server, ModInfoEntities modInfoDb, string modName, string gameVersion)
        {
            GameVersion = gameVersion;
            var files = Directory.GetFiles(server.MapPath($"/Areas/Product/Files/{modName}/{gameVersion}"));
            var versionInfo =
                modInfoDb.VersionInfoes.FirstOrDefault(vi => vi.ModName.Name == modName && vi.GameVersion == gameVersion);
            Preposition = versionInfo?.PrepositionModName;
            if (Preposition != null)
            {
                var version = new Version(versionInfo.PrepositionVersion,
                    (Version.FileType)Enum.Parse(typeof(Version.FileType), versionInfo.PrepositionType));
                Files =
                    files.Select(path =>
                        new Tuple<FileInfo, ModFile>(new FileInfo(path),
                            new ModFileWithPreposition(Path.GetFileName(path), Preposition, version))).ToList();
            }
            else
            {
                Files =
                    files.Select(path =>
                        new Tuple<FileInfo, ModFile>(new FileInfo(path), new ModFile(Path.GetFileName(path)))).ToList();
            }
        }
    }
}