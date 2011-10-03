#if Silverlight
using System.Windows.Controls;
using System.Windows.Navigation;
#else
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
#endif

namespace PizzaHouse.Metro.Views
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}