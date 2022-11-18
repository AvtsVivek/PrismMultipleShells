using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimplePrism.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SimplePrismShell.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {

        private string _windowTitle = default!;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { SetProperty(ref _windowTitle, value); }
        }
        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private readonly IShellService _shellService;
        private readonly IRegionManager _rootRegionManager;
        private IRegionManager _scopedRegionManagerForThisShell;

        public ShellWindowViewModel(IShellService shellService, IRegionManager regionManager)
        {
            WindowTitle = "Main Shell Window";
            OpenShellCommand = new DelegateCommand<string>(OpenShell);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _shellService = shellService;
            _rootRegionManager = regionManager;
            _scopedRegionManagerForThisShell = regionManager;
        }

        public void SetScopedRegionManager(IRegionManager scopedRegionManager) 
        {
            _scopedRegionManagerForThisShell= scopedRegionManager;
        }

        //public void RequestNavigate(string regionName, string viewName)
        //{
        //    //_scopedRegionManagerForThisShell.RequestNavigate(regionName, viewName);
        //    _rootRegionManager.RequestNavigate(regionName, viewName);
        //}

        private void OpenShell(string viewName)
        {
            _shellService.ShowShell(viewName);
        }

        private void Navigate(string viewName)
        {
            //_rootRegionManager.RequestNavigate("ContentRegion", viewName);
            _scopedRegionManagerForThisShell.RequestNavigate("ContentRegion", viewName);
        }
    }
}
