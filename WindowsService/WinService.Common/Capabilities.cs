using System;

namespace WinService.Common
{
    [Flags]
    public enum Capabilities
    {
        CanStart = 1,
        CanStop = 2,
        CanContinue = 4,
        CanPause = 8,
        CanShutdown = 16,

        Simple = CanStart | CanStop,
        All = Simple | CanContinue | CanPause | CanShutdown
    }
}
