using System.Collections.Generic;
using OrderDomain.Models.OrderAggregate;

namespace OrderApplication.Orders.GetAll
{
    public class OrderGetAllResult
    {
        public OrderGetAllResult(List<Order> orders)
        {
            Orders = orders;
        }

        public List<Order> Orders { get; private set; }
    }
}