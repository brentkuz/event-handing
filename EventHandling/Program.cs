using EventHandling.Bus;
using EventHandling.Events;
using EventHandling.Handlers;
using System;

namespace EventHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            var evtBus = new EventBus();
            
            
            evtBus.RegisterHandler(new HandlerTwo());
            evtBus.RegisterHandler(new HandlerOne());

            evtBus.ProcessEvent(new EventOne
            {
                EventOneData = "Event One Message!"
            });

            evtBus.ProcessEvent(new AddEvent
            {
                Val1 = 2,
                Val2 = 8
            });

            Console.ReadKey();
        }
    }
}
