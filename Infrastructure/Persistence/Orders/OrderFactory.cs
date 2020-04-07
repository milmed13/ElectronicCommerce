using System;
using System.Collections.Generic;
using OrderDomain.Models.OrderAggregate;

namespace Infrastructure.Persistence.Orders
{
    public class OrderFactory : IOrderFactory
    {
        public Order Create(OrderNumber orderNumber, DateTime orderDate, Address address, List<OrderItem> items)
        {
            return new Order(orderNumber, orderDate, address, items);
        }
    }
}