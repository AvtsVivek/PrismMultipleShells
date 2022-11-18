# Shows how to work with multiple shells.
- So we need to do the following to fix the problems we discussed in the earlier example.
- asdf


- First add a behaviour class in SimplePrism.Core.Prism
- Next add that behavior so prism will know about it. Override the method ConfigureDefaultRegionBehaviors in bootstrapper class. 
```cs
protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
{
    base.ConfigureDefaultRegionBehaviors(regionBehaviors);
    regionBehaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey, typeof(RegionManagerAwareBehavior));
}
```
- Finally modify ViewAViewModel so that it will be RegionManagerAware. Impliment IRegionManagerAware interface. This means the view model will now use the RegionManager from the interface for navigation and not the global or root region manager. The global region manager is no longer needed, so remove it. Ctor injection should also be removed.
-  