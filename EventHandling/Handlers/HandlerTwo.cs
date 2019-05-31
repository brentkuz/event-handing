using EventHandling.Events;
using EventHandling.Infrastructure;
using System;

namespace EventHandling.Handlers
{
    [HandlerOrdinal(Order.Second)]
    public class HandlerTwo : HandlerBase
    {
        public void Handler(EventOne e)
        {
            Console.WriteLine("HandlerTwo handling EventOne: " + e.EventOneData);
        }

        public void Handler(AddEvent e)
        {
            Console.WriteLine("HandlerTwo adding value: Sum = " + ((e.Val1 + e.Val2) * 10));
        }
    }
}
