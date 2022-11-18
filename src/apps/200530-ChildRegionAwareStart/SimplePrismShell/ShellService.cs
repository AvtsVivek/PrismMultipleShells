using DryIoc;
using Prism.Ioc;
using Prism.Regions;
using SimplePrism.Core;
using SimplePrism.Core.Prism;
using SimplePrismShell.Views;

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

        public void ShowShell(string uri)
        {
            var shell = _container.Resolve<ShellWindow>();

            var scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);

            RegionManagerAware.SetRegionManagerAware(shell, scopedRegion);

            scopedRegion.RequestNavigate("ContentRegion", uri);

            shell.Show();
        }
    }
}
