using System;
using nText.Core.Impl;
using nText.Core.Interface;
using NUnit.Framework;

namespace nText.Core.Test.Impl
{
    [TestFixture]
    public class TextStatisticsTest
    {
        //Following a Method_State_Result pattern

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ArgumentNull_ArgumentNullException()
        {
            ITextStatistics stats = new TextStatistics(null);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ArgumentEmptyString_ArgumentNullException()
        {
            ITextStatistics stats = new TextStatistics(String.Empty);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Build_HavingEmptyText_ArgumentNullException()
        {
            ITextStatistics stats = new TextStatistics();
            stats.Build();
            Assert.Fail("Shouldn't reach this code");
        }
    }
}