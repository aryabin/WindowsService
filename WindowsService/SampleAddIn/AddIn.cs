using System;
using System.ComponentModel.Composition;
using System.Threading;
using WinService.Common;

namespace SampleAddIn
{
    [Export(typeof(IWinServiceAddIn))]
    public class AddIn : IWinServiceAddIn
    {
        private IWorker _worker;

        public string Name { get; } = "Sample AddIn";

        public Capabilities Capabilities { get; } = Capabilities.Simple;

        public void OnStart(CancellationToken cancellationToken)
        {
            _worker = new PeriodicWorker(() =>
            {
                Console.WriteLine("DoWork");
            }, cancellationToken);
            _worker.DoWork();
        }

        public void OnStop()
        {

        }

        public void OnContinue()
        {

        }

        public void OnPause()
        {

        }

        public void OnShutdown()
        {

        }
    }
}
