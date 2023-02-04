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
            Console.WriteLine($"AddIn {Name} - OnStart");
            _worker = new PeriodicWorker(() =>
            {
                Console.WriteLine($"AddIn {Name} - DoWork");
            }, cancellationToken);
            _worker.DoWork();
        }

        public void OnStop()
        {
            Console.WriteLine($"AddIn {Name} - OnStop");
        }

        public void OnContinue()
        {
            Console.WriteLine($"AddIn {Name} - OnContinue");
        }

        public void OnPause()
        {
            Console.WriteLine($"AddIn {Name} - OnPause");
        }

        public void OnShutdown()
        {
            Console.WriteLine($"AddIn {Name} - OnShutdown");
        }
    }
}
