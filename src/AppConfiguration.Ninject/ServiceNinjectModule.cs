using ActivityTracker.EventStore;
using ActivityTracker.Service;
using Ninject.Modules;
using ToLog4NetEventStore;

namespace AppConfiguration.Ninject
{
    public class ServiceNinjectModule : NinjectModule
    {
        public ServiceNinjectModule()
        {
        }

        public override void Load()
        {
            Bind<IActivityTrackerService>().To<ActivityTrackerService>();
            Bind<IEventStore>().To<MemoryEventStore.MemoryEventStore>().WhenInjectedInto<LoggingEventStoreDecorator>();
            Bind<IEventStore>().To<LoggingEventStoreDecorator>();
        }
    }
}