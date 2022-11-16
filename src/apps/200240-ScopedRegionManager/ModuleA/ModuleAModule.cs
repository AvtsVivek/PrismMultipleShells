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

            // We are creating scoped region manager for each one of these views.

            var view1 = containerProvider.Resolve<ViewA>();
            IRegionManager r1 = region.Add(view1, null, true);
            region.Activate(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            IRegionManager r2 = region.Add(view2, null, true);
            region.Activate(view2);

            var view3 = containerProvider.Resolve<ViewA>();
            IRegionManager r3 = region.Add(view3, null, true);
            region.Activate(view3);

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
