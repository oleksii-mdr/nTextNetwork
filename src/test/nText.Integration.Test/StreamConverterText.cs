using System.IO;
using nText.Core;
using nText.Core.Test.Util;
using NUnit.Framework;

namespace nText.Integration.Test
{
    [TestFixture]
    public class StreamConverterText
    {
        [TestCase(@"Data\En\1661-8.txt")]
        [TestCase(@"Data\Ru\16527-8.txt")]
        public void ToText_ReadContentOfAFile_NotNullOrEmpty(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            Stream stream = File.OpenRead(fName);
            IStreamConverter c = new StreamConverter();
            string actual = c.ToText(stream);
            Assert.IsNotNullOrEmpty(actual);
        }
    }
}