namespace ActivityTracker.WindowsServiceHost
{
    internal interface IActivityTrackerService
    {
        void OnStart();
        void OnStop();
    }
}