﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome.Areas.Product
{
    public class Version : IComparable<Version>
    {
        public enum FileType
        {
            Demo,
            Pre
        }

        public enum Test
        {
            Pre,
            Alpha,
            Beta,
            Gamma
        }

        private readonly string _version;
        public FileType Type { get; }

        public string FileVersion { get; set; }

        public Test TestVersion { get; set; }

        public Version(string version, FileType type)
        {
            Type = type;
            _version = $"{type} {version}";
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
            var versions1 = this.FileVersion.Split('.').Select(Int32.Parse).ToArray();
            var versions2 = other.FileVersion.Split('.').Select(Int32.Parse).ToArray();
            for (var i = 0; i < versions1.Length; i++)
            {
                var c = versions1[i].CompareTo(versions2[i]);
                if (c != 0) return c;
            }
            return this.TestVersion.CompareTo(other.TestVersion);
        }

        public override string ToString() => _version;
    }
}