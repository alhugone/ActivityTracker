using ActivityTracker.Events;
using System.Collections.Generic;

namespace ActivityTracker.EventStore
{
    public class MemoryEventStore : IEventStore
    {
        protected LinkedList<IActivityEvent> _events = new LinkedList<IActivityEvent>();
        public void Store(IActivityEvent activityEvent)
        {
            _events.AddLast(activityEvent);
        }
    }
}
