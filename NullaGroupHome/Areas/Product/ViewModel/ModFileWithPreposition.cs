using System;
using System.Linq;
using System.Xml;

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

        public ModFileWithPreposition(string file, XmlDocument xmlDocument) : base(file)
        {
            PrepositionName = (xmlDocument.SelectSingleNode("/version-info/preposition") as XmlElement)?.GetAttribute("name");
            var element =
                xmlDocument.SelectSingleNode("/version-info/preposition")?
                    .ChildNodes.OfType<XmlElement>()
                    .SingleOrDefault(xe =>
                        xe.GetAttribute("type") == this.FileVersion.Type.ToString() &&
                        xe.GetAttribute("version") == this.FileVersion.ToString().Split(' ')[1]);
            if (element == null)
            {
                PrepositionVersion = null;
                return;
            }
            PrepositionVersion = new Version(element.SelectSingleNode("version").InnerText,
                (Version.FileType) Enum.Parse(typeof (Version.FileType), element.SelectSingleNode("type").InnerText));
        }
    }
}