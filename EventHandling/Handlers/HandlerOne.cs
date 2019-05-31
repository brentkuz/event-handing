using EventHandling.Events;
using EventHandling.Infrastructure;
using System;

namespace EventHandling.Handlers
{
    [HandlerOrdinal(Order.First)]
    public class HandlerOne : HandlerBase
    {
        public void Handler(EventOne e)
        {
            Console.WriteLine("HandlerOne handling EventOne: " + e.EventOneData);
        }

        public void Handler(AddEvent e)
        {
            Console.WriteLine("HandlerOne adding value with multiplier of 10: Sum = " + (e.Val1 + e.Val2));
        }
    }
}
