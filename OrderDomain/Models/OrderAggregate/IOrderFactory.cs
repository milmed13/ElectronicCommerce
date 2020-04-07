using System;
using System.Collections.Generic;

namespace OrderDomain.Models.OrderAggregate
{
    public interface IOrderFactory
    {
        Order Create(OrderNumber orderNumber, DateTime orderDate, Address address, List<OrderItem> items);
    }
}