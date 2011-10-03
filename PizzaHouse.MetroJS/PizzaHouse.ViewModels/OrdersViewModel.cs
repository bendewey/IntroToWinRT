using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace PizzaHouse.ViewModels
{
    public sealed class OrdersViewModel
    {
        private readonly IOrderService _orderService;

        public OrdersViewModel() : this(new OrderService()) {}

        public OrdersViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            InProgressOrders = _orderService.GetInProgressOrders().Cast<IOrder>().ToList();
            PreviousOrders = orderService.GetPreviousOrders().Cast<IOrder>().ToList();
        }

        public IList<IOrder> InProgressOrders { get; set; }
        public IList<IOrder> PreviousOrders { get; set; }
        public IOrder SelectedOrder { get; set; }
    }
}
