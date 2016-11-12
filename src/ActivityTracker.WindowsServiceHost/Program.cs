using Topshelf;
using Topshelf.Ninject;

namespace ActivityTracker.WindowsServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<IActivityTrackerService>(sc =>
                {
                    sc.ConstructUsingNinject();
                    sc.WhenStarted(s => s.OnStart());
                    sc.WhenStopped(s => s.OnStop());
                });
                x.UseNinject(new ServiceNinjectModule());
                x.UseLog4Net("log4net.xml");
                x.SetServiceName("ActivityTracker");
            });
        }
    }
}
