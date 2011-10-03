#if Silverlight
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
#endif

namespace PizzaHouse.Metro
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame != null && ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }
    }
}