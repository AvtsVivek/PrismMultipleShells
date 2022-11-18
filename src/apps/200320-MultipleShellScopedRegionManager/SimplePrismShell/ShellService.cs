using DryIoc;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Regions;
using SimplePrism.Core;
using SimplePrismShell.ViewModels;
using SimplePrismShell.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrismShell
{
    public class ShellService : IShellService
    {
        public ShellService(IRegionManager regionManager, IContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        private IRegionManager _regionManager { get; }
        private IContainer _container { get; }

        //public void RequestNavigate(string regionName, string uri)
        //{
        //    scopedRegion.RequestNavigate(regionName, uri);
        //}

        public void ShowShell(string uri)
        {
            var shellWindow = _container.Resolve<ShellWindow>();
            var shellWindowViewModel = (ShellWindowViewModel)shellWindow.DataContext;

            var scopedRegionManager = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shellWindow, scopedRegionManager);
            
            shellWindowViewModel.SetScopedRegionManager(scopedRegionManager);
            scopedRegionManager.RequestNavigate("ContentRegion", uri);
            shellWindow.Show();
        }
    }
}
