using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace NewsAndInterests.Models
{
    public class Section
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("cards")]
        public List<JObject> Cards { get; set; }
    }
}