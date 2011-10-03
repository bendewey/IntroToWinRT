using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouse.ViewModel;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace PizzaHouse
{
    partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new OrdersViewModel();
        }
    }
}
