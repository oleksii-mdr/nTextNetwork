using System.Collections.Generic;
using System.IO;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Test.Utils;
using NUnit.Framework;
using System.Linq;

namespace nTextNetwork.Integration.Test
{
    [TestFixture]
    public class JsonSerrializerTest
    {
        [TestCase(@"Data\En\1661-8.txt")]
        public void Serialize_Dictionary_Take_nRecord(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            const int expectedCount = 100;

            Stream stream = File.OpenRead(fName);

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(stream);

            var iterator = stats.WordFrequencyDictionary.Take(expectedCount);
            var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

            var serrializer = new JsonSerrializer<IDictionary<string, int>>();
            string json = serrializer.Serialize(dictionary);

            int actual = json.Split(':').Count() - 1;

            Assert.AreEqual(expectedCount, actual);
        }

        [TestCase(@"Data\En\1661-8.txt")]
        public void Serialize_Json_For_Jit(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            const int count = 100;

            const string expectedJson = "{\"children\":[{\"children\":[{\"children\":[],\"data\":{\"playcount\":\"4513\",\"$color\":\"#8E7032\",\"image\":\"http://userserve-ak.last.fm/serve/300x300/11403219.jpg\",\"$area\":4513},\"id\":\"the\",\"name\":\"the\"}]}]}";

            //for now file exist in the bin directory
            Stream stream = File.OpenRead(fName);

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(stream);

            var iterator = stats.WordFrequencyDictionary.Take(count);
            var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

            var serrializer = new JsonSerrializer<IDictionary<string, int>>();
            string json = serrializer.SerializeForJit(dictionary);

        }
        
    }
}