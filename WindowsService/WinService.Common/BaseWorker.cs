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
            this._cancellationToken = cancellationToken;
            this._action = action;
            this._delay = delay;
        }

        public abstract void DoWork();
    }
}
