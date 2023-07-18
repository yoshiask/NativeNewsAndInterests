using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsAndInterests.Models
{
    public class River
    {
        [JsonProperty("useRotPos")]
        public bool UseRotPos { get; set; }

        [JsonProperty("templateVariant")]
        public string TemplateVariant { get; set; }

        [JsonProperty("subSections")]
        public List<Section> SubSections { get; set; }
    }
}