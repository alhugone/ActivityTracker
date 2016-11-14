using System;

namespace ActivityTracker.Events
{
    public abstract class ActivityEvent : IActivityEvent
    {
        public DateTimeOffset Timestamp { get; } = DateTimeOffset.Now;
    }
}
