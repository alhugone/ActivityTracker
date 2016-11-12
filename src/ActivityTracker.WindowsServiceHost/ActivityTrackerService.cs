using ActivityTracker.Events;
using ActivityTracker.EventStore;

namespace ActivityTrackerWindowsService
{
    internal class ActivityTrackerService : IActivityTrackerService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ActivityTrackerService));
        private static IEventStore _eventStore;

        public ActivityTrackerService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public void OnStart()
        {
            _eventStore.Store(new ServiceStartedEvent());
            log.Info("Service started");
        }

        public void OnStop()
        {
            _eventStore.Store(new ServiceStoppedEvent());
            log.Info("Service stopped");
        }
    }
}