using System.IO;
using nTextNetwork.Core.Test.Utils;
using NUnit.Framework;
using TextReader = nTextNetwork.Core.Text.TextReader;

namespace nTextNetwork.Integration.Test.Text
{
    [TestFixture]
    public class TextReaderTest
    {
        [TestCase(@"Data\En\1661-8.txt", 1024, 1032)]
        [TestCase(@"Data\En\1661-8.txt", 1032, 1032)]
        public void ReadUntilSpace_TextFile_ReadCharsTillSpace(string fName,
            int minCount, int expectedRead)
        {
            TestPrecondition.EnsureFileExist(fName);
            string chunk;
            int actual;
            using (Stream stream = File.OpenRead(fName))
            {
                using (var reader = new TextReader(stream))
                {
                    actual = reader.ReadUntilSpace(0, minCount, out chunk);
                }
            }
            Assert.AreEqual(expectedRead, actual);
            Assert.IsNotNullOrEmpty(chunk);
        }
    }
}