using Newtonsoft.Json;

namespace NewsAndInterests.Models
{
    public class Regions
    {
        [JsonProperty("river")]
        public River River { get; set; }
    }
}