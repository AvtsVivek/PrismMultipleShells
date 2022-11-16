using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {

            _regionManager.RegisterViewWithRegion("ChildRegion", typeof(ViewB));

            var region = _regionManager.Regions["ContentRegion"];

            var view1 = containerProvider.Resolve<ViewA>();
            region.Add(view1);
            region.Activate(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            //region.Add(view2);
            //region.Activate(view2);

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
