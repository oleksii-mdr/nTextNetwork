using System;
using System.Collections.Generic;
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

        [Test]
        public void Serialize_Dictionary_with_known_value()
        {
            var knownValues = new Dictionary<string, int> {{"aaa", 10}, {"bb", 25}, {"c", 40}};

            IDictionarySerrializer<string, int> dictionary = new DictionarySerrializer<string, int>();

            string actualResult = dictionary.Serrialize(knownValues);
            string expectedResult = "{\"aaa\":10,\"bb\":25,\"c\":40}";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}