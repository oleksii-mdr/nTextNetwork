using System;
using System.Configuration;
using System.IO;
using nText.Core.Impl;
using nText.Core.Interface;
using nText.Core.Test.Util;
using NUnit.Framework;

namespace nText.Integration.Test
{
    [TestFixture]
    public class TextStatisticBuilderTest
    {
        [TestCase(@"Data\En\1661-8.txt")]
        public void Build_TextFile_ValidStatistics(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            Stream stream = File.OpenRead(fName);
            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var actual = builder.Build(stream);
            Assert.IsNotNull(actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Build_StreamIsNull_ArgumentNullException()
        {
            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            builder.Build(null);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Build_StreamIsEmpty_ArgumentNullException()
        {
            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            builder.Build(new MemoryStream());
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void ToText_StreamIsTooLarge_OutOfMemoryException()
        {
            IStreamConverter c = new StreamConverter();
            string str = ConfigurationManager
                                    .AppSettings["maxAllowedInputBytes"];

            int max;
            TestPrecondition.EnsureCanParse(str, out max);
            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            builder.Build(new MemoryStream(new byte[max + 1]));
            Assert.Fail("Shouldn't reach this code");
        }
    }
}