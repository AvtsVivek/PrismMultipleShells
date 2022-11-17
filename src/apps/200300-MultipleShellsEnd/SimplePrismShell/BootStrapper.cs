using ModuleA;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SimplePrism.Core;
using SimplePrismShell.ViewModels;
using SimplePrismShell.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimplePrismShell
{
    public class BootStrapper : PrismBootstrapper
    {
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

            // The following is not working. The command is getting executed, but the navigation is not happening.
            //var firstShellWindow = (ShellWindow)shell;
            //var firstShellWindowViewModel = (ShellWindowViewModel)firstShellWindow.DataContext;
            //firstShellWindowViewModel.NavigateCommand.Execute("ViewA");

            // Ok, got the answer. If you right click the base.InitializeShell(shell); to see the implimentation, you will notice that its just assigning the Shell.
            // Its not actually showing it. The actual Show method is called in the OnInitialized method. So go to that method.
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            // This works.
            var firstShellWindow = (ShellWindow)Shell;
            var firstShellWindowViewModel = (ShellWindowViewModel)firstShellWindow.DataContext;
            firstShellWindowViewModel.NavigateCommand.Execute("ViewA");
        }
    }
}
