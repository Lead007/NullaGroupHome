using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    public class ModFile : IComparable<ModFile>
    {
        public enum FileType
        {
            Demo,
            Pre
        }

        public string FileName { get; }

        public string ModName { get; }

        public FileType Type { get; }

        public Version FileVersion { get; }

        public ModFile(string fileName)
        {
            this.FileName = fileName;
            var nameType = string.Format(@"(.+)(\s-\s)({0})(\s)((\d|\.)+)((α|β|γ)?)(\.jar)",
                Enum.GetNames(typeof (FileType))
                    .Aggregate(string.Empty, (current, name) => current += (name + "|"))
                    .TrimEnd('|'));
            var groups = Regex.Match(fileName, nameType).Groups;
            this.ModName = groups[1].Value;
            this.Type = (FileType)(Enum.Parse(typeof(FileType), groups[3].Value));
            this.FileVersion = new Version(groups[5].Value + groups[7].Value);
        }

        public int CompareTo(ModFile other)
        {
            var c1 = this.Type.CompareTo(other.Type);
            return c1 != 0 ? c1 : this.FileVersion.CompareTo(other.FileVersion);
        }
    }
}