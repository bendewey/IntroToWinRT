#if Silverlight
using System.Windows.Controls;
using System.Windows.Navigation;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
#endif

namespace PizzaHouse.Metro.Views
{
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private void HyperlinkButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element == null || string.IsNullOrWhiteSpace(element.Tag as string)) return;
            Frame.Navigate("PizzaHouse.Metro.Views." + element.Tag);
        }
    }
}