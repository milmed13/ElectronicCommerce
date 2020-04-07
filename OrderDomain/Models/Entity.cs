using System;
using System.Collections.Generic;

namespace OrderDomain.Models
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }
    }
}