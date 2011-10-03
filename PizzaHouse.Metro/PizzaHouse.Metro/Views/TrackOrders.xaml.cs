using System;
using System.Linq;
#if Silverlight
using System.Windows.Controls;
using System.Windows.Navigation;
#else
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PizzaHouse.Metro;
#endif
using PizzaHouse.ViewModel;
using Windows.UI.Xaml.Controls.Primitives;

namespace PizzaHouse.Metro.Views
{
    public partial class TrackOrders
    {
        public TrackOrders()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = DataContext as OrdersViewModel;
            GroupedCollectionViewSource.Source = vm.OrderGroups;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        void ItemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.ViewModel.SelectedOrder = (sender as Selector).SelectedItem as Order;
            Frame.Navigate("PizzaHouse.Metro.Views.OrderStatus");
        }
    }
}