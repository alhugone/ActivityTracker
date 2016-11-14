namespace ActivityTracker.WindowsServiceHost
{
    internal interface IActivityTrackerService
    {
        void OnStart();
        void OnStop();
        void OnLogon();
        void OnLogoff();
        void Unlock();
        void OnLock();
    }
}