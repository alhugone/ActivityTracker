using System;

namespace ActivityTracker.Events
{
    public interface IEvent
    {
        DateTimeOffset Timestamp { get; }
    }
}