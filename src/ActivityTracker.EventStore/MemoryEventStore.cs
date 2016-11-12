using ActivityTracker.Events;
using System.Collections.Generic;

namespace ActivityTracker.EventStore
{
    public class MemoryEventStore : IEventStore
    {
        protected LinkedList<IEvent> _events = new LinkedList<IEvent>();
        public void Store(IEvent @event)
        {
            _events.AddLast(@event);
        }
    }
}
