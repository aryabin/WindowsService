using System;
using System.Threading;
using System.Threading.Tasks;

namespace WinService.Common
{
    public class EventBasedWorker : BaseWorker
    {
        public EventBasedWorker(Action action, CancellationToken cancellationToken, int delay = 10000) : base(action, cancellationToken, delay) { }

        public override void DoWork()
        {
            Task.Run(async () =>
            {
                _action.Invoke();
                while (!_cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(_delay, _cancellationToken);
                }
            }, _cancellationToken);
        }
    }
}
