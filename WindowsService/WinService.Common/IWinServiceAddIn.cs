using System.Threading;

namespace WinService.Common
{
    public interface IWinServiceAddIn
    {
        string Name { get; }
        Capabilities Capabilities { get; }
        void OnStart(CancellationToken cancellationToken);
        void OnStop();
        void OnContinue();
        void OnPause();
        void OnShutdown();
    }
}
