using Newtonsoft.Json;

namespace nTextNetwork.Presentation.Web.Models
{
    public class Data
    {
        [JsonProperty("count")]
        public string Count;

        [JsonProperty("$color")]
        public string Color;

        [JsonProperty("$area")]
        public int Area;
    }
}
