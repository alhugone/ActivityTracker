using ActivityTracker.Events;
using ActivityTracker.EventStore;

namespace ActivityTracker.WindowsServiceHost
{
    internal class ActivityTrackerService : IActivityTrackerService
    {
        private static IEventStore _eventStore;

        public ActivityTrackerService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public void OnStart()
        {
            _eventStore.Store(new ServiceStartedEvent());
        }

        public void OnStop()
        {
            _eventStore.Store(new ServiceStoppedEvent());
        }

        public void OnLogon()
        {
            _eventStore.Store(new UserLogonEvent());
        }

        public void OnLogoff()
        {
            _eventStore.Store(new UserLogoffEvent());
        }

        public void Unlock()
        {
            _eventStore.Store(new UserLockSessionEvent());
        }

        public void OnLock()
        {
            _eventStore.Store(new UserUnlockSessionEvent());
        }
    }
}