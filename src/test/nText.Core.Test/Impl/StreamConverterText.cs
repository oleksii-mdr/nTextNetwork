using System;
using System.Configuration;
using System.IO;
using nText.Core.Impl;
using nText.Core.Interface;
using nText.Core.Test.Util;
using NUnit.Framework;

namespace nText.Core.Test.Impl
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToText_StreamIsEmpty_ArgumentNullException()
        {
            IStreamConverter c = new StreamConverter();
            c.ToText(new MemoryStream());
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
            string actual = c.ToText(new MemoryStream(new byte[max + 1]));
            Assert.Fail("Shouldn't reach this code");
        }
    }
}