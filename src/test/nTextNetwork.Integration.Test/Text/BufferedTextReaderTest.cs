using System;
using System.IO;
using System.Text;
using nTextNetwork.Core.Test.Utils;
using nTextNetwork.Core.Text;
using NUnit.Framework;
using System.Collections.Generic;

namespace nTextNetwork.Integration.Test.Text
{
    [TestFixture]
    public class BufferedTextReaderTest
    {
        private readonly List<char> simpleSeparators = new List<char> { ' ' };
        

        [TestCase(@"Data\En\1661-8.txt", -1)]
        [TestCase(@"Data\En\1661-8.txt", 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void Read_ReadCount_Exception(string fName,
            int invalidReadCount)
        {
            TestPrecondition.EnsureFileExist(fName);
            using (Stream stream = File.OpenRead(fName))
            {
                using (var reader = new BufferedTextReader(stream))
                {
                    string chunk;
                    
                    reader.Read(invalidReadCount, out chunk,
                        simpleSeparators);
                }
            }
            Assert.Fail("Shouldn't reach this code");
        }

        [TestCase(@"Data\En\1661-8.txt")]
        public void Read_ReadAll_CountMatch(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            int actual = 0;
            const int bufSize = 1024;
            long expected;

            using (Stream stream = File.OpenRead(fName))
            {
                expected = stream.Length;
                using (var reader = new BufferedTextReader(stream))
                {
                    while (reader.CanRead)
                    {
                        string chunk;
                        int singleRead = reader.Read(
                            bufSize, out chunk, simpleSeparators);

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
        public void Read_ReadAll_TextMatch(string fName, int bufferSize)
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
                using (var reader = new BufferedTextReader(stream))
                {
                    while (reader.CanRead)
                    {
                        string chunk;
                        reader.Read(bufferSize, out chunk,
                            simpleSeparators);
                        sb.Append(chunk);
                    }
                }
            }
            string actual = sb.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}