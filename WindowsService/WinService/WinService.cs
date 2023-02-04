using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using WinService.Common;

namespace WinService
{
    public partial class WinService : ServiceBase
    {
        [ImportMany]
        private IEnumerable<IWinServiceAddIn> _addIns;
        private CancellationTokenSource _cancellationTokenSource;

        public WinService()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            InitializeComponent();
            InitializeAddIns();
        }

        private void InitializeAddIns()
        {
            var catalog = new DirectoryCatalog(Constants.CURRENT_DIRECTORY, Constants.ALL_CLASS_LIBRARIES);
            var container = new CompositionContainer(catalog);

            try
            {
                container.ComposeParts(this);
            }
            catch (ChangeRejectedException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        protected override void OnStart(string[] args)
        {
            Parallel.ForEach(_addIns.Where(a => a.Capabilities.HasFlag(Capabilities.CanStart)), a => a.OnStart(_cancellationTokenSource.Token));
        }

        protected override void OnStop()
        {
            _cancellationTokenSource.Cancel();
            Parallel.ForEach(_addIns.Where(a => a.Capabilities.HasFlag(Capabilities.CanStop)), a => a.OnStop());
        }

        protected override void OnContinue()
        {
            Parallel.ForEach(_addIns.Where(a => a.Capabilities.HasFlag(Capabilities.CanContinue)), a => a.OnContinue());
        }

        protected override void OnPause()
        {
            Parallel.ForEach(_addIns.Where(a => a.Capabilities.HasFlag(Capabilities.CanPause)), a => a.OnPause());
        }

        protected override void OnShutdown()
        {
            Parallel.ForEach(_addIns.Where(a => a.Capabilities.HasFlag(Capabilities.CanShutdown)), a => a.OnShutdown());
        }

        internal void StartService()
        {
            OnStart(null);
        }

        internal void StopService()
        {
            OnStop();
        }
    }
}
