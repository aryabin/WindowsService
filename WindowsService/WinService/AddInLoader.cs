using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using WinService.Common;

namespace WinService
{
    internal class AddInLoader : ILoader<IEnumerable<IWinServiceAddIn>>
    {
        [ImportMany]
        private IEnumerable<IWinServiceAddIn> _addIns;

        public IEnumerable<IWinServiceAddIn> GetLoadedData()
        {
            return _addIns;
        }

        public void LoadData()
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
    }
}
