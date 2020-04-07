using System;

namespace OrderApplication.Orders
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(int id)
        {
            Id = id;
        }

        public OrderNotFoundException(int id, string message) : base(message)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
