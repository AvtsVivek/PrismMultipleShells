using System.Windows;

namespace SimplePrismShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override Window CreateShell()
        //{
        //    return Container.Resolve<ShellWindow>();
        //}

        //protected override void RegisterTypes(IContainerRegistry containerRegistry)
        //{

        //}

        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    moduleCatalog.AddModule<ModuleAModule>();
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new BootStrapper();
            bootstrapper.Run();
        }

    }
}
