using EventHandling.Events;
using EventHandling.Handlers;

namespace EventHandling.Bus
{
    public interface IEventBus
    {
        void RegisterHandler(HandlerBase handler);
        void UnRegisterHandler(HandlerBase handler);
        void ProcessEvent(EventBase e);
    }
}
