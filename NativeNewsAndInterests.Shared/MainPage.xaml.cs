using NewsAndInterests;
using NewsAndInterests.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeNewsAndInterests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<object> Cards { get; } = new ObservableCollection<object>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (var card in ProcessCards((await Api.GetFeed()).Cards))
            {
                Cards.Add(card);
            }
        }

        private List<object> ProcessCards(IEnumerable<object> items)
        {
            var cards = new List<object>();
            foreach (var item in items)
            {
                var genericItem = item is Card ? (Card)item : Card.ToType<Card>(item);
                switch (genericItem?.Type)
                {
                    case "article":
                        cards.Add(Card.ToType<ArticleCard>(item));
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
