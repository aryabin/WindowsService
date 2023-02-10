using System;
using System.Threading;

namespace WinService.Common
{
    public abstract class BaseWorker : IWorker
    {
        protected CancellationToken _cancellationToken;
        protected Action _action;
        protected int _delay;

        public BaseWorker(Action action, CancellationToken cancellationToken, int delay)
        {
            _cancellationToken = cancellationToken;
            _action = action;
            _delay = delay;
        }

        public abstract void DoWork();
    }
}
