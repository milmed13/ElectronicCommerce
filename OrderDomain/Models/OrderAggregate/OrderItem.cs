using System;
using OrderDomain.Interfaces;

namespace OrderDomain.Models.OrderAggregate
{
    public class OrderItem : Entity
    {
        public OrderItem(int? productId, string productName, int unitPrice, int units)
        {
            if (productName == null) throw new ArgumentNullException(nameof(productName));
            if (productName.Length > 50) throw new ArgumentOutOfRangeException(nameof(productName));
            if (units < 1) throw new ArgumentOutOfRangeException(nameof(units));

            ProductId = ProductId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Units = units;
        }

        public int? ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }

        public int GetTotal()
        {
            return UnitPrice * Units;
        }
    }
}