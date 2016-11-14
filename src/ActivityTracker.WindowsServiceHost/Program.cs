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
                    sc.WhenSessionChanged(OnSessionChanged);
                });
                x.UseNinject(new ServiceNinjectModule());
                x.UseLog4Net("log4net.xml");
                x.SetServiceName("ActivityTracker");
            });
        }

        private static void OnSessionChanged(IActivityTrackerService trackerService, HostControl host, SessionChangedArguments arg)
        {
            switch (arg.ReasonCode)
            {
                case SessionChangeReasonCode.SessionLogon:
                    trackerService.OnLogon();
                    break;
                case SessionChangeReasonCode.SessionLogoff:
                    trackerService.OnLogoff();
                    break;
                case SessionChangeReasonCode.SessionLock:
                    trackerService.OnLock();
                    break;
                case SessionChangeReasonCode.SessionUnlock:
                    trackerService.Unlock();
                    break;
            }
        }
    }
}
