using System;

namespace ActivityTrackerWindowsService
{
    internal class ActivityTrackerService : IActivityTrackerService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ActivityTrackerService));
        public void OnStart()
        {
            log.Info("Service started");
        }

        public void OnStop()
        {
            log.Info("Service stopped");
        }
    }
}