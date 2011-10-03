using System;
using System.Collections.Generic;

namespace PizzaHouse.ViewModel
{
    public sealed class Order
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public IList<string> OrderItems { get; set; }
        public string Status { get; set; }
    }
}