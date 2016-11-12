using System;

namespace ActivityTracker.Events
{
    public interface IEvent
    {
        DateTimeOffset Timestamp { get; }
    }

    public abstract class Event : IEvent
    {
        public DateTimeOffset Timestamp { get; } = DateTimeOffset.Now;
    }
    public class ServiceStartedEvent : Event { }
    public class ServiceStoppedEvent : Event { }
}
