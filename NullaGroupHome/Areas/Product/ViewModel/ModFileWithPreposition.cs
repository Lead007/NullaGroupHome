using System;
using System.Linq;
using System.Xml;
using NullaGroupHome.Models;

namespace NullaGroupHome.Areas.Product.ViewModel
{
    public class ModFileWithPreposition : ModFile
    {
        public string PrepositionName { get; }

        public Version PrepositionVersion { get; }

        public ModFileWithPreposition(string file, string prepositionName, Version prepositionVersion) : base(file)
        {
            PrepositionName = prepositionName;
            PrepositionVersion = prepositionVersion;
        }
    }
}