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
            _eventStore.Store(new ServiceStartedActivityEvent());
        }

        public void OnStop()
        {
            _eventStore.Store(new ServiceStoppedActivityEvent());
        }

        public void OnLogon()
        {
            _eventStore.Store(new UserLogonActivityEvent());
        }

        public void OnLogoff()
        {
            _eventStore.Store(new UserLogoffActivityEvent());
        }

        public void Unlock()
        {
            _eventStore.Store(new UserLockSessionActivityEvent());
        }

        public void OnLock()
        {
            _eventStore.Store(new UserUnlockSessionActivityEvent());
        }
    }
}