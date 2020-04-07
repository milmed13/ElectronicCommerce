using OrderDomain.Models.OrderAggregate;

namespace OrderDomain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}