using System;
using System.Collections.Generic;
using OrderDomain.Interfaces;

namespace OrderDomain.Models.OrderAggregate
{
    /// <summary>
    /// 受注番号
    /// TODO: モールごとに命名規則が異なり、受注番号に規則性や区切りごとに意味を持つケースがあるので表現できるといいね
    /// </summary>
    public class OrderNumber : ValueObject
    {
        public OrderNumber() { }

        public OrderNumber(string orderNumber)
        {
            Value = orderNumber;
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}