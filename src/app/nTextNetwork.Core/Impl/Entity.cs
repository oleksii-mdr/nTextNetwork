using System.Collections.Generic;
using Newtonsoft.Json;

namespace nTextNetwork.Core.Impl
{
    public class Node
    {
        [JsonProperty("children")]
        public List<Node> Children = new List<Node>();

        [JsonProperty("data")]
        public Data Data;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;
    }

    public class Data
    {
        [JsonProperty("playcount")]
        public string PlayCount;

        [JsonProperty("$color")]
        public string Color;

        [JsonProperty("image")]
        public string Image;

        [JsonProperty("$area")]
        public int Area;
    }

}
