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
        }
    }
}