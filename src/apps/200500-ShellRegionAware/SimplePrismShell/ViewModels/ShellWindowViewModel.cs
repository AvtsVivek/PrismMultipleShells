using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimplePrism.Core;
using SimplePrism.Core.Prism;

namespace SimplePrismShell.ViewModels
{
    public class ShellWindowViewModel : BindableBase, IRegionManagerAware
    {
        public IRegionManager RegionManager { get; set; } = default!;

        private string _windowTitle = default!;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { SetProperty(ref _windowTitle, value); }
        }
        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private readonly IShellService _shellService;

        public ShellWindowViewModel(IShellService shellService)
        {
            WindowTitle = "Main Shell Window";
            OpenShellCommand = new DelegateCommand<string>(OpenShell);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _shellService = shellService;

        }

        private void OpenShell(string viewName)
        {
            _shellService.ShowShell(viewName);
        }

        private void Navigate(string viewName)
        {
            RegionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
