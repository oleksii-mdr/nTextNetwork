using System.Collections.Generic;
using nTextNetwork.Presentation.Web.Models;
using NUnit.Framework;

namespace nTextNetwork.Presentation.Web.Test
{
    [TestFixture]
    public class JsonSerializerForJitTest
    {
        [Test]
        public void Serialize_SmallDictionary_NotNullOrEmpty()
        {
            IDictionary<string,int> dictionary = new Dictionary<string, int>();
            dictionary.Add(new KeyValuePair<string, int> ("Cat",1));
            dictionary.Add(new KeyValuePair<string, int>("Dog", 2));
            dictionary.Add(new KeyValuePair<string, int>("Rabbit", 3));
           
            var serrializer = new JsonSerializerForJit();
            string json = serrializer.Serialize(dictionary);
            Assert.IsNotNullOrEmpty(json);
        }
    }
}