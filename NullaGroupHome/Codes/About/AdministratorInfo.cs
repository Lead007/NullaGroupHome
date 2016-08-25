using System;
using System.Collections.Generic;
using System.Linq;

namespace NullaGroupHome.About
{
    public struct AdministratorInfo
    {
        /// <summary>名字</summary>
        public string Name { get; set; }
        /// <summary>身份</summary>
        public string Status { get; set; }
        /// <summary>所在组</summary>
        public string Group { get; set; }

        public override string ToString() => $"{Name}，{Status}，{Group}";
    }

    public struct AdministratorInfos
    {
        public AdministratorInfo[] Administrators { get; set; }
    }
}