using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimplePrism.Core.Prism;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IRegionManagerAware
    {
        public DelegateCommand NavigateCommand { get; set; } = default!;
        public IRegionManager RegionManager { get; set; } = default!;

        private string _welcomeMessage = "Hello from ViewAViewModel";
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { SetProperty(ref _welcomeMessage, value); }
        }
    }
}
