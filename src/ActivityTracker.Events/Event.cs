using System;

namespace ActivityTracker.Events
{
    public abstract class Event : IEvent
    {
        public DateTimeOffset Timestamp { get; } = DateTimeOffset.Now;
    }
}
