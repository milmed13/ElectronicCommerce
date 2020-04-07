using OrderDomain.Models.OrderAggregate;

namespace OrderApplication.Orders.Get
{
    public class OrderGetResult
    {
        public OrderGetResult(Order order)
        {
            Order = order;
        }

        public Order Order { get; private set; }
    }
}