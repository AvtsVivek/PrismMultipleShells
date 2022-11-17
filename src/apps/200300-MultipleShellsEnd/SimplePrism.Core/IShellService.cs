using System;
using System.Security.Policy;

namespace SimplePrism.Core
{
    public interface IShellService
    {
        void ShowShell(string uri);
        //void RequestNavigate(string regionName, string uri);
    }
}
