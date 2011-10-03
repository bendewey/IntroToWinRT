namespace PizzaHouse.ViewModels
{
    public sealed class OrderStatus : IOrderStatus
    {
        public static string Baking { get { return "Baking"; } }
        public static string Delivered  { get { return "Delivered"; } }
    }

    public interface IOrderStatus { }
}