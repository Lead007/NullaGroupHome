using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    public class ModFile : IComparable<ModFile>
    {

        public string FileName { get; }

        public string ModName { get; }


        public Version FileVersion { get; }

        public ModFile(string fileName)
        {
            this.FileName = fileName;
            var nameType = $@"(.+)(\s-\s)({Enum.GetNames(typeof (Version.FileType))
                .Aggregate(string.Empty, (current, name) => current += (name + "|"))
                .TrimEnd('|')})(\s)((\d|\.)+)((α|β|γ)?)(\.jar)";
            var groups = Regex.Match(fileName, nameType).Groups;
            this.ModName = groups[1].Value;
            var type = (Version.FileType)Enum.Parse(typeof(Version.FileType), groups[3].Value);
            this.FileVersion = new Version(groups[5].Value + groups[7].Value, type);
        }

        public int CompareTo(ModFile other)
        {
            var c1 = this.FileVersion.Type.CompareTo(other.FileVersion.Type);
            return c1 != 0 ? c1 : this.FileVersion.CompareTo(other.FileVersion);
        }
    }
}