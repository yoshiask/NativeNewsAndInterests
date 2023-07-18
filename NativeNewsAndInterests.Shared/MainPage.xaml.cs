using NewsAndInterests;
using NewsAndInterests.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
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

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
#if WINDOWS_UWP
            // Set active window colors
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;

            // Set inactive window colors
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;

            // Hide default title bar.
            coreTitleBar.ExtendViewIntoTitleBar = true;
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
#else
            // Reset all colors
            titleBar.ButtonBackgroundColor = null;
            titleBar.ButtonInactiveBackgroundColor = null;
            coreTitleBar.ExtendViewIntoTitleBar = false;
#endif
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            CaptionButtonColumn.Width = new GridLength(sender.SystemOverlayRightInset);

            TitleBarRow.Height = new GridLength(sender.Height);
            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(TitleBarGrab);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var feed = await Api.GetFeed();
            foreach (var card in Card.ProcessCards(feed.Regions.River.SubSections.SelectMany(s => s.Cards)))
            {
                Cards.Add(card);
            }
        }
    }
}
