using ActivityTracker.EventStore;
using Ninject.Modules;

namespace ActivityTracker.WindowsServiceHost
{
    internal class ServiceNinjectModule : NinjectModule
    {
        public ServiceNinjectModule()
        {
        }

        public override void Load()
        {
            Bind<IActivityTrackerService>().To<ActivityTrackerService>();
            Bind<IEventStore>().To<MemoryEventStore>().WhenInjectedInto<LoggingEventStoreDecorator>();
            Bind<IEventStore>().To<LoggingEventStoreDecorator>();
        }
    }
}