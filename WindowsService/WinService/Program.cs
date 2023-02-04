using System;
using System.ServiceProcess;

namespace WinService
{
    internal static class Program
    {
        static void Main()
        {
            WinService winService = new WinService();

            if (Environment.UserInteractive)
            {
                Console.WriteLine($"Starting \"{winService.ServiceName}\" windows service...");
                winService.StartService();
                Console.WriteLine($"Windows service \"{winService.ServiceName}\" started.");
                Console.WriteLine("Press any key to stop service.");
                Console.ReadKey();
                Console.WriteLine($"Stopping \"{winService.ServiceName}\" windows service...");
                winService.StopService();
                winService.Dispose();
                Console.WriteLine($"Windows service \"{winService.ServiceName}\" stopped.");
                return;
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                    winService
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
