using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaHouse.ViewModel
{
    public interface IOrderService
    {
        IEnumerable<Order> GetInProgressOrders();
        IEnumerable<Order> GetPreviousOrders();
    }

    internal class OrderService : IOrderService
    {
        public IEnumerable<Order> GetInProgressOrders()
        {
            return from order in Orders
                   where order.Status != OrderStatus.Delivered
                   select order;
        }

        public IEnumerable<Order> GetPreviousOrders()
        {
            return from order in Orders
                   where order.Status == OrderStatus.Delivered
                   select order;
        }

        private static PizzaHouseComponent.OrderData _data = new PizzaHouseComponent.OrderData();
        private static readonly Order[] Orders = new[]
        {
            new Order
                {
                    Id = 1,
                    Date = DateTime.Now.AddMinutes(-12),
                    CustomerName = "John Doe",
                    CustomerAddress = "123 W. Houston St",
                    CustomerPhone = "(212) 555-4433",
                    Status = OrderStatus.Baking,
                    OrderItems =
                        (new[] {"Pepperoni Pizza", "Galic Knots"}).ToList()
                },
            new Order
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-10),
                    CustomerName = _data.Name,
                    CustomerAddress = "123 W. Houston St",
                    CustomerPhone = "(212) 555-4433",
                    Status = OrderStatus.Delivered,
                    OrderItems = (new[] {"2 Supreme Pizza"}).ToList()
                },
            new Order
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-20),
                    CustomerName = "John Doe",
                    CustomerAddress = "123 W. Houston St",
                    CustomerPhone = "(212) 555-4433",
                    Status = OrderStatus.Delivered,
                    OrderItems = (new[] {"Cheese Pizza"}).ToList()
                },
            new Order
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-100),
                    CustomerName = "John Doe",
                    CustomerAddress = "123 W. Houston St",
                    CustomerPhone = "(212) 555-4433",
                    Status = OrderStatus.Delivered,
                    OrderItems = (new[] {"Pepperoni Pizza"}).ToList()
                },
        };

    }
}
