using System;
using System.IO;
using System.Text;
using nTextNetwork.Core.Test.Utils;
using NUnit.Framework;
using TextReader = nTextNetwork.Core.Text.TextReader;

namespace nTextNetwork.Integration.Test.Text
{
    [TestFixture]
    public class TextReaderTest
    {
        [TestCase(@"Data\En\1661-8.txt", -1)]
        [TestCase(@"Data\En\1661-8.txt", 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadUntilSpace_ReadCount_Exception(string fName,
            int invalidReadCount)
        {
            TestPrecondition.EnsureFileExist(fName);
            string chunk;
            int actual;
            using (Stream stream = File.OpenRead(fName))
            {
                using (var reader = new TextReader(stream))
                {
                    actual = reader.ReadUntilSpace(invalidReadCount, out chunk);
                }
            }
            Assert.Fail("Shouldn't reach this code");
        }

        [TestCase(@"Data\En\1661-8.txt")]
        public void ReadUntilSpace_ReadAll_CountMatch(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            int actual = 0;
            const int bufSize = 1024;
            long expected;

            using (Stream stream = File.OpenRead(fName))
            {
                expected = stream.Length;
                using (var reader = new TextReader(stream))
                {
                    while (reader.CanRead)
                    {
                        string chunk;
                        int singleRead = reader.ReadUntilSpace(
                            bufSize, out chunk);

                        actual += singleRead;
                    }
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"Data\En\1661-8.txt", 1)]
        [TestCase(@"Data\En\1661-8.txt", 8)]
        [TestCase(@"Data\En\1661-8.txt", 124)]
        [TestCase(@"Data\En\1661-8.txt", 512)]
        [TestCase(@"Data\En\1661-8.txt", 1024)]
        [TestCase(@"Data\En\1661-8.txt", 10*1024)]

        [TestCase(@"Data\Ru\16527-8.txt", 1)]
        [TestCase(@"Data\Ru\16527-8.txt", 8)]
        [TestCase(@"Data\Ru\16527-8.txt", 124)]
        [TestCase(@"Data\Ru\16527-8.txt", 512)]
        [TestCase(@"Data\Ru\16527-8.txt", 1024)]
        [TestCase(@"Data\Ru\16527-8.txt", 10 * 1024)]
        public void ReadUntilSpace_ReadAll_TextMatch(string fName, int bufferSize)
        {
            TestPrecondition.EnsureFileExist(fName);
            var sb = new StringBuilder();
            string expected;

            using (Stream stream = File.OpenRead(fName))
            {
                using (var reader = new StreamReader(stream))
                {
                    expected = reader.ReadToEnd();
                }
            }
            using (Stream stream = File.OpenRead(fName))
            {
                using (var reader = new TextReader(stream))
                {
                    while (reader.CanRead)
                    {
                        string chunk;
                        reader.ReadUntilSpace(bufferSize, out chunk);
                        sb.Append(chunk);
                    }
                }
            }
            string actual = sb.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}