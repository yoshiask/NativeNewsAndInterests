using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsAndInterests.Models
{
    public class Card
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subCards")]
        public List<object> SubCards { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cardId")]
        public int? CardId { get; set; }

        public static TCardType ToType<TCardType>(object item) where TCardType : Card
        {
            return (item as Newtonsoft.Json.Linq.JObject)?.ToObject<TCardType>();
        }
    }
}
