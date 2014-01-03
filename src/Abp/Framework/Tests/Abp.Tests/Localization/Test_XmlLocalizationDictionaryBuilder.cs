using Abp.Localization.Sources.XmlFiles;
using NUnit.Framework;

namespace Abp.Tests.Localization
{
    [TestFixture]
    public class Test_XmlLocalizationDictionaryBuilder
    {
        [Test]
        public void Can_Build_LocalizationDictionary_From_Xml_String()
        {
            var dictionary = XmlLocalizationDictionaryBuilder.BuildFomXmlString(
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<localizationDictionary culture=""tr"">
  <texts>
    <text name=""hello"" value=""Merhaba"" />
    <text name=""world"" value=""D�nya"" />
  </texts>
</localizationDictionary>"
                );

            Assert.AreEqual("tr", dictionary.Culture.Name);
            Assert.AreEqual("Merhaba", dictionary["hello"]);
            Assert.AreEqual("D�nya", dictionary["world"]);
        }
    }
}