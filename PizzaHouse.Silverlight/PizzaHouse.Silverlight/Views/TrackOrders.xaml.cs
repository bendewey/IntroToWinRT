using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;
using PizzaHouse.ViewModel;

namespace PizzaHouse.Silverlight
{
    public partial class TrackOrders : Page
    {
        public TrackOrders()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.ViewModel.SelectedOrder = e.AddedItems.OfType<Order>().FirstOrDefault();
            NavigationService.Navigate(new Uri("/OrderStatus", UriKind.Relative));
        }
    }
}