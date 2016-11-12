using ActivityTracker.EventStore;
using Ninject.Modules;
using System;

namespace ActivityTrackerWindowsService
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