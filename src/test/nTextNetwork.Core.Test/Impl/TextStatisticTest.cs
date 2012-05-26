using System;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;
using NUnit.Framework;

namespace nTextNetwork.Core.Test.Impl
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