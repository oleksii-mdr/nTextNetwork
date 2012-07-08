using System.Collections.Generic;
using Newtonsoft.Json;

namespace nTextNetwork.Presentation.Web.Models.LightWeight
{
    /// <summary>
    /// This guy returns data for the TreeMap control.
    /// </summary>
    public class TreeMapNode
    {
        [JsonProperty("children")]
        public List<TreeMapNode> Children = new List<TreeMapNode>();

        [JsonProperty("data")]
        public TreeMapNodeItem Data;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;
    }
}