using System;
using System.Collections.Generic;
using System.Linq;
using OrderDomain.Models;
using OrderDomain.Interfaces;

namespace OrderDomain.Models.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        protected Order()
        {
        }

        public Order(OrderNumber orderNumber, DateTime orderDate, Address address, List<OrderItem> items)
        {
            if (orderNumber == null) throw new ArgumentNullException(nameof(orderNumber));
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (items.Count() < 1) throw new ArgumentOutOfRangeException(nameof(items));

            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Address = address;
            orderItems = items;
        }

        public OrderNumber OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Address Address { get; private set; }

        private List<OrderItem> orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => orderItems;

        public int GetTotal()
        {
            return orderItems.Sum(o => o.GetTotal());
        }
    }
}