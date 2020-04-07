using System;
using System.Collections.Generic;
using OrderDomain.Interfaces;

namespace OrderDomain.Models.OrderAggregate
{
    public class Address : ValueObject
    {
        public Address() { }

        public Address(string postalCode, int prefecture, string address1, string address2)
        {
            if (postalCode.Length > 7) throw new ArgumentOutOfRangeException(nameof(postalCode));
            if (address1 == null) throw new ArgumentNullException(nameof(address1));
            if (address1.Length > 50) throw new ArgumentOutOfRangeException(nameof(address1));
            if (address2 == null) throw new ArgumentNullException(nameof(address2));
            if (address2.Length > 50) throw new ArgumentOutOfRangeException(nameof(address2));

            PostalCode = postalCode;
            Prefecture = prefecture;
            Address1 = address1;
            Address2 = address2;
        }

        public string PostalCode { get; private set; }
        public int Prefecture { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PostalCode;
            yield return Prefecture;
            yield return Address1;
            yield return Address2;
        }
    }
}