using NewsAndInterests;
using NewsAndInterests.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
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
            foreach (var card in Card.ProcessCards((await Api.GetFeed()).Cards))
            {
                Cards.Add(card);
            }
        }
    }
}
