using System;
using System.Threading;
using System.Threading.Tasks;

namespace WinService.Common
{
    public class PeriodicWorker : BaseWorker
    {
        public PeriodicWorker(Action action, CancellationToken cancellationToken, int period = 1000) : base(action, cancellationToken, period) { }

        public override void DoWork()
        {
            Task.Run(async () =>
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    _action.Invoke();
                    await Task.Delay(_delay, _cancellationToken);
                }
            }, _cancellationToken);
        }
    }
}
