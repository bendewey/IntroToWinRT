using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaHouse.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ChildWindow errorWin = new ErrorWindow(e.Uri);
            errorWin.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var navigationService = ((Page)ContentFrame.Content).NavigationService;
            if (navigationService != null && navigationService.CanGoBack)
            {
                navigationService.GoBack();  
            }
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var navigationService = ((Page)ContentFrame.Content).NavigationService;
            BackButton.IsEnabled = !(navigationService == null || !navigationService.CanGoBack);
        }
    }
}