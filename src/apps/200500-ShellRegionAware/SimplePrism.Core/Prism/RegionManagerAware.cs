using Prism.Regions;
using System.Windows;

namespace SimplePrism.Core.Prism
{
    public static class RegionManagerAware
    {
        public static void SetRegionManagerAware(object item, IRegionManager regionManager)
        {
            var rmAware = item as IRegionManagerAware;
            if (rmAware != null)
                rmAware.RegionManager = regionManager;

            var rmAwareFrameworkElement = item as FrameworkElement;
            if (rmAwareFrameworkElement != null)
            {
                var rmAwareDataContext = rmAwareFrameworkElement.DataContext as IRegionManagerAware;
                if (rmAwareDataContext != null)
                    rmAwareDataContext.RegionManager = regionManager;
            }
        }
    }

}
