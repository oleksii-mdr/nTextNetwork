using Newtonsoft.Json;

namespace nTextNetwork.Presentation.Web.Models.LightWeight
{
    /// <summary>
    ///This class represents a box from the TreeMap control.
    /// </summary>
    public class TreeMapNodeItem
    {
        [JsonProperty("count")]
        public string Count;

        [JsonProperty("$color")]
        public string Color;

        [JsonProperty("$area")]
        public double Area;
    }
}
