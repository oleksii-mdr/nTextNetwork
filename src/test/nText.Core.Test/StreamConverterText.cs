using System;
using System.Configuration;
using System.IO;
using nText.Core.Test.Util;
using NUnit.Framework;

namespace nText.Core.Test
{
    [TestFixture]
    public class StreamConverterText
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToText_StreamIsNull_ArgumentNullException()
        {
            IStreamConverter c = new StreamConverter();
            c.ToText(null);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        public void ToText_StreamIsEmpty_EmptyString()
        {
            IStreamConverter c = new StreamConverter();
            string actual = c.ToText(new MemoryStream());
            Assert.IsEmpty(actual);
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
            string actual = c.ToText(new MemoryStream(new byte[max + 1]));
            Assert.Fail("Shouldn't reach this code");
        }
    }
}