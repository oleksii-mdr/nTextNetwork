using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;

namespace nTextNetwork.Core.Test.Impl
{
    [TestFixture]
    public class JsonSerrializerTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Serrialize_DictionaryIsNull_ArgumentNullException()
        {
            IJsonSerializer<Type> serrializer = new JsonSerializer<Type>();
            serrializer.Serialize(null); //this shall throw an exception
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        public void Serialize_Dictionary_ValidJson()
        {
            var knownValues = new Dictionary<string, int>
            {
                { "aaa", 100 }, 
                { "bb", 55 }, 
                { "c", 40 }
            };
            string expected = "{\"aaa\":100,\"bb\":55,\"c\":40}";
            var serrializer = new JsonSerializer<IDictionary<string, int>>();
            var actual = serrializer.Serialize(knownValues);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Deserialize_Dictionary_ValidJson()
        {
            var expected = new Dictionary<string, int>
            {
                { "aaa", 100 }, 
                { "bb", 55 }, 
                { "c", 40 }
            };
            string testValues = "{\"aaa\":100,\"bb\":55,\"c\":40}";
            var serrializer = new JsonSerializer<IDictionary<string, int>>();
            var actual = serrializer.Deserialize(testValues);

            Assert.AreEqual(expected, actual);
        }
    }
}