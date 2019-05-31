using EventHandling.Events;

namespace EventHandling.Handlers
{
    public interface IHandler 
    {
        void Handle(EventBase e);
    }
}
