using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ShellWindowViewModel()
        {
            WindowTitle = "Main Shell Window";
        }
    }
}
