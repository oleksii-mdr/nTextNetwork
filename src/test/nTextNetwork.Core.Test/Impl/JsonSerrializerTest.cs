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
            IJsonSerrializer<Type> serrializer = new JsonSerrializer<Type>();
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
            var serrializer = new JsonSerrializer<IDictionary<string, int>>();
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
            var serrializer = new JsonSerrializer<IDictionary<string, int>>();
            var actual = serrializer.Deserialize(testValues);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Serialize_Dictionary_Take_nRecord()
        {
            const int expectedCount = 100;

            //for now file exist in the bin directory
            Stream stream = File.OpenRead("1661-8.txt");

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(stream);

            var iterator = stats.WordFrequencyDictionary.Take(expectedCount);
            var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

            var serrializer = new JsonSerrializer<IDictionary<string, int>>();
            string json = serrializer.Serialize(dictionary);

            int actual = json.Split(':').Count() - 1;

            Assert.AreEqual(expectedCount, actual);
        }

        [Test]
        public void Serialize_Json_For_Jit()
        {
            const int count = 100;

            const string expectedJson = "{\"children\":[{\"children\":[{\"children\":[],\"data\":{\"playcount\":\"4513\",\"$color\":\"#8E7032\",\"image\":\"http://userserve-ak.last.fm/serve/300x300/11403219.jpg\",\"$area\":4513},\"id\":\"the\",\"name\":\"the\"}]}]}";

            //for now file exist in the bin directory
            Stream stream = File.OpenRead("1661-8.txt");

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(stream);

            var iterator = stats.WordFrequencyDictionary.Take(count);
            var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

            var serrializer = new JsonSerrializer<IDictionary<string, int>>();
            string json = serrializer.SerializeForJit(dictionary);
            
        }
    }
}