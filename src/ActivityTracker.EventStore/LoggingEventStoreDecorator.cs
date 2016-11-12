﻿using ActivityTracker.Events;
using log4net;

namespace ActivityTracker.EventStore
{
    public class LoggingEventStoreDecorator : IEventStore
    {
        protected readonly IEventStore _eventStore;
        protected readonly ILog _log;
        public LoggingEventStoreDecorator(IEventStore eventStore, ILog log)
        {
            _eventStore = eventStore;
            _log = log ?? LogManager.GetLogger(typeof(LoggingEventStoreDecorator));
        }

        public LoggingEventStoreDecorator(IEventStore eventStore) : this(eventStore, null) { }

        public void Store(IEvent @event)
        {
            _log.Debug($"Event {@event.GetType().Name} : {@event.Timestamp} stored.");
        }
    }
}
