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

        public static List<object> ProcessCards(IEnumerable<object> items)
        {
            var cards = new List<object>();
            foreach (var item in items)
            {
                var genericItem = item is Card card ? card : ToType<Card>(item);
                switch (genericItem?.Type)
                {
                    case "article":
                        cards.Add(ToType<ArticleCard>(item));
                        break;

                    case "StockQuote":
                        cards.Add(ToType<StockQuoteCard>(item));
                        break;

                    case "group":
                    case "topStories":
                        cards.AddRange(ProcessCards(genericItem.SubCards));
                        break;

                    default:
                        cards.Add(genericItem);
                        break;
                }
            }
            return cards;
        }
    }
}
