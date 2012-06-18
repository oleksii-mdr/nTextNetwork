using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Utils;
using JsonSerializer = ServiceStack.Text.JsonSerializer;

namespace nTextNetwork.Core.Impl
{
    public class JsonSerrializer<T> : IJsonSerrializer<T> where T : class
    {
        public T Deserialize(string json)
        {
            Precondition.EnsureNotNull("json", json);
            return JsonSerializer.DeserializeFromString<T>(json);
        }

        public string Serialize(T obj)
        {
            Precondition.EnsureNotNull("obj", obj);
            return JsonSerializer.SerializeToString(obj);
        }

        public string SerializeForJit(Dictionary<string,int> dictionary)
        {
            Precondition.EnsureNotNull("dictionary", dictionary);

            Node root = new Node();

            foreach (var item in dictionary)
            {
                Node child = new Node()  { Id = item.Key, Name = item.Key };
                Data data = new Data()
                                {
                                    Area = item.Value, 
                                    Color = ColorHelper.GetHexColor(), 
                                    PlayCount = item.Value.ToString(CultureInfo.InvariantCulture),
                                    Image = "http://userserve-ak.last.fm/serve/300x300/11403219.jpg"
                                };

                child.Data = data;

                root.Children.Add(child);
            }
                                     
            return JsonConvert.SerializeObject(root);
        }
    }
}