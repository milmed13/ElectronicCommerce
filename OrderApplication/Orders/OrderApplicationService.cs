using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using OrderApplication.Orders.Get;
using OrderApplication.Orders.GetAll;
using OrderApplication.Orders.Register;
using OrderDomain.Models.OrderAggregate;
using OrderDomain.Services;

namespace OrderApplication.Orders
{
    public class OrderApplicationService
    {
        private readonly IOrderFactory orderFactory;
        private readonly IOrderRepository orderRepository;
        private readonly OrderService orderService;

        public OrderApplicationService(IOrderFactory orderFactory, IOrderRepository orderRepository, OrderService orderService)
        {
            this.orderFactory = orderFactory;
            this.orderRepository = orderRepository;
            this.orderService = orderService;
        }

        public async Task<OrderGetResult> Get(OrderGetCommand command)
        {
            var order = await orderRepository.GetByIdWithItemsAsync(command.Id);

            if (order == null)
            {
                throw new OrderNotFoundException(command.Id, "注文が見つかりませんでした。");
            }

            return new OrderGetResult(order);
        }

        public async Task<OrderGetAllResult> GetAllAsync()
        {
            var orders = await orderRepository.GetAllAsync();
            return new OrderGetAllResult(orders);
        }

        public OrderRegisterResult Register(OrderRegisterCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var order = orderFactory.Create(command.orderNumber, command.orderDate, command.address, command.items);
                orderRepository.Save(order);

                transaction.Complete();

                return new OrderRegisterResult(order.Id);
            }
        }
    }
}