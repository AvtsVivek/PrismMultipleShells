# Duplicate Region Exception.

- This example shows an exception that can occur in Prism application.
- 

```cs
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
```

- Question: How many number of region managers this will create? 4 or 2?