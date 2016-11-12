using ActivityTracker.Events;

namespace ActivityTracker.EventStore
{
    public interface IEventStore
    {
        void Store(IEvent @event);
    }

    public class EventStore : IEventStore
    {
        public void Store(IEvent @event) { }
    }
}
