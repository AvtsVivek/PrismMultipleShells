using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase
    {
        private string _welcomeMessage = "Hello from ViewBViewModel";
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { SetProperty(ref _welcomeMessage, value); }
        }
    }
}
