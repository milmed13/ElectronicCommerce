using System;
using System.Collections.Generic;
using OrderDomain.Models.OrderAggregate;

namespace OrderApplication.Orders.Register
{
    public class OrderRegisterCommand
    {
        public OrderRegisterCommand(OrderNumber orderNumber, DateTime orderDate, Address address, List<OrderItem> items)
        {
            this.orderNumber = orderNumber;
            this.orderDate = orderDate;
            this.address = address;
            this.items = items;
        }

        public OrderNumber orderNumber { get; private set; }
        public DateTime orderDate { get; private set; }
        public Address address { get; private set; }
        public List<OrderItem> items { get; private set; }
    }
}