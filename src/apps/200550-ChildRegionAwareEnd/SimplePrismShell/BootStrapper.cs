using Microsoft.Xaml.Behaviors;
using ModuleA;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SimplePrism.Core;
using SimplePrism.Core.Prism;
using SimplePrismShell.ViewModels;
using SimplePrismShell.Views;
using System.Windows;

namespace SimplePrismShell
{
    public class BootStrapper : PrismBootstrapper
    {
        public BootStrapper()
        {

        }
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellService, ShellService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>();
        }

        protected override void InitializeShell(DependencyObject shell)
        {
            base.InitializeShell(shell);

            var regionManager = RegionManager.GetRegionManager((Shell));
            RegionManagerAware.SetRegionManagerAware(Shell, regionManager);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var firstShellWindow = (ShellWindow)Shell;
            var firstShellWindowViewModel = (ShellWindowViewModel)firstShellWindow.DataContext;
            firstShellWindowViewModel.NavigateCommand.Execute("ViewA");
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey, typeof(RegionManagerAwareBehavior));
        }
    }
}
