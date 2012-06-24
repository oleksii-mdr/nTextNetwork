using System.Collections.Generic;
using Newtonsoft.Json;

namespace nTextNetwork.Presentation.Web.Models
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
}