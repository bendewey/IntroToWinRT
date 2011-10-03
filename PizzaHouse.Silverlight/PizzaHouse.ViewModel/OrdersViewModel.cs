using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Windows.UI.Xaml.Data;

namespace PizzaHouse.ViewModel
{
    public sealed class OrdersViewModel
    {
        private readonly IOrderService _orderService;

        public OrdersViewModel() : this(new OrderService()) {}

        public OrdersViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            InProgressOrders = _orderService.GetInProgressOrders().ToList();
            PreviousOrders = orderService.GetPreviousOrders().ToList();
            OrderGroups = new List<OrderGroup>() { 
                new OrderGroup { Title="In Progress Orders", Orders = InProgressOrders },
                new OrderGroup { Title="Previous Orders", Orders = PreviousOrders }
            };
            
        }

        public IList<Order> InProgressOrders { get; set; }
        public IList<Order> PreviousOrders { get; set; }
        public IEnumerable<OrderGroup> OrderGroups { get; set; }
        public Order SelectedOrder { get; set; }
    }

    public sealed class OrderGroup : List<Order>, IGroupInfo
    {
        public string Title { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public object Key
        {
            get { return this; }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return Orders.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
