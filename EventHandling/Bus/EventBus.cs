using System.Collections.Generic;
using EventHandling.Events;
using EventHandling.Handlers;
using EventHandling.Infrastructure;

namespace EventHandling.Bus
{
    public class EventBus : IEventBus
    {
        protected List<HandlerBase> handlers = new List<HandlerBase>();

        public void ProcessEvent(EventBase e)
        {
            foreach(var handler in handlers)
            {
                handler.Handle(e);
            }
        }

        public void RegisterHandler(HandlerBase handler)
        {
            handlers.Add(handler);
            SortHandlers();
        }

        public void UnRegisterHandler(HandlerBase handler)
        {
            handlers.Remove(handler);
            SortHandlers();
        }

        protected void SortHandlers()
        {
            handlers.Sort(delegate (HandlerBase h1, HandlerBase h2)
            {
                var h1Order = (int)h1.GetType().GetAttributeValue((HandlerOrdinal ordinal) => ordinal.Order);
                var h2Order = (int)h2.GetType().GetAttributeValue((HandlerOrdinal ordinal) => ordinal.Order);
                return h1Order < h2Order ? -1 : h1Order > h2Order ? 1 : 0;
            });
        }
    }
}
