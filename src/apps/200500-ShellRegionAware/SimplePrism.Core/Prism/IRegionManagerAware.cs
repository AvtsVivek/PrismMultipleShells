using Prism.Regions;

namespace SimplePrism.Core.Prism
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
