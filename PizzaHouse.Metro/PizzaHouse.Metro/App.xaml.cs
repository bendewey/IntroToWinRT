using System;
using System.Collections.Generic;
using PizzaHouse.ViewModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;


namespace PizzaHouse.Metro
{
    partial class App
    {
        public static OrdersViewModel ViewModel { get; set; }

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            ViewModel = new OrdersViewModel();
            Window.Current.Content = new MainPage() { DataContext = ViewModel };
            Window.Current.Activate();
        }

        public static void ShowGroupedCollection()
        {
            var page = new GroupedCollectionPage();
            Window.Current.Content = page;
        }

        public static void ShowCollectionSummary(IEnumerable<object> collection)
        {
            var page = new CollectionSummaryPage();
            Window.Current.Content = page;
        }

        public static void ShowDetail(IEnumerable<object> collection, object item)
        {
            var page = new DetailPage();
            Window.Current.Content = page;
        }
    }
}
