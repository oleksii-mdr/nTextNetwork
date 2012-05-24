using System;
using NUnit.Framework;
using nText.Core.Impl;
using nText.Core.Interfaces;

namespace nText.Core.Test.Impl
{
    [TestFixture]
    public class DictionarySerrializerTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Serrialize_DictionaryIsNull_ArgumentNullException()
        {
            IDictionarySerrializer<string, int> d = new DictionarySerrializer<string, int>();
            d.Serrialize(null); //this shall throw an exception
            Assert.Fail("Shouldn't reach this code");
        }
    }
}