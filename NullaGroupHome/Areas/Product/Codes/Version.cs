using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    public class Version : IComparable<Version>
    {
        public enum Test
        {
            Pre,
            Alpha,
            Beta,
            Gamma
        }
        public string FileVersion { get; set; }

        public Test TestVersion { get; set; }

        public Version(string version)
        {
            switch (version[version.Length - 1])
            {
                case 'α':
                    TestVersion = Test.Alpha;
                    break;
                case 'β':
                    TestVersion = Test.Beta;
                    break;
                case 'γ':
                    TestVersion = Test.Gamma;
                    break;
                default:
                    TestVersion = Test.Pre;
                    FileVersion = version;
                    break;
            }
            if (FileVersion == null) FileVersion = version.Substring(0, version.Length - 1);
        }

        public int CompareTo(Version other)
        {
            var versions1 = this.FileVersion.Split('.').Select(int.Parse).ToArray();
            var versions2 = other.FileVersion.Split('.').Select(int.Parse).ToArray();
            for (var i = 0; i < versions1.Length; i++)
            {
                var c = versions1[i].CompareTo(versions2[i]);
                if (c != 0) return c;
            }
            return this.TestVersion.CompareTo(other.TestVersion);
        }
    }
}