using NewsAndInterests.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NativeNewsAndInterests.Selectors
{
    public class CardTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Default { get; set; }
        public DataTemplate Article { get; set; }
        public DataTemplate StockQuote { get; set; }
        public DataTemplate WeatherSummary { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            switch (item)
            {
                case ArticleCard _:
                    return Article;

                case StockQuoteCard _:
                    return StockQuote;

                case WeatherSummaryCard _:
                    return WeatherSummary;

                default:
                case Card _:
                    return Default;
            }
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}
