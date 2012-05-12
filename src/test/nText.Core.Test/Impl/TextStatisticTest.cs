using System;
using nText.Core.Impl;
using nText.Core.Interface;
using NUnit.Framework;

namespace nText.Core.Test.Impl
{
    [TestFixture]
    public class TextStatisticTest
    {
        //Following a Method_State_Result pattern

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ArgumentNull_ArgumentNullException()
        {
            ITextStatistic stats = new TextStatistic(null);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ArgumentEmptyString_ArgumentNullException()
        {
            ITextStatistic stats = new TextStatistic(String.Empty);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Build_HavingEmptyText_ArgumentNullException()
        {
            ITextStatistic stats = new TextStatistic();
            stats.Build();
            Assert.Fail("Shouldn't reach this code");
        }
    }
}