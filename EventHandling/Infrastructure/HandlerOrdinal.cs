using EventHandling.Handlers;
using System;

namespace EventHandling.Infrastructure
{
    public class HandlerOrdinal : Attribute
    {
        public HandlerOrdinal(Order order)
        {
            Order = order;
        }
        public Order Order { get; protected set; }
    }
}
