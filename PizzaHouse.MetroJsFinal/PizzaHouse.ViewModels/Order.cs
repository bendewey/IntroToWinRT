using System;
using System.Collections.Generic;

namespace PizzaHouse.ViewModels
{
    public sealed class Order : IOrder
    {
        public int Id { get; set; }
        internal DateTime Date { get; set; }
        public string DateText { get { return Date.ToString(); } }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public IList<string> OrderItems { get; set; }
        public string Status { get; set; }
    }

    public interface IOrder
    {
        int Id { get; set; }
        string DateText { get; }
        string CustomerName { get; set; }
        string CustomerPhone { get; set; }
        string CustomerAddress { get; set; }
        IList<string> OrderItems { get; set; }
        string Status { get; set; }
    }
}