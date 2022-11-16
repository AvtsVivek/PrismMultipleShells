# Duplicate Region Exception.

- This example shows an exception that can occur in Prism application.
- Run the app from Visual Studio 2022 or above and you will see an exception 

> An exception occurred while creating a region with name 'ChildRegion'. The exception was: System.ArgumentException: Region with the given name is already registered: ChildRegion

- The reason for this exception is we are trying to register a region twice with the same name.

```cs
public void OnInitialized(IContainerProvider containerProvider)
{
    _regionManager.RegisterViewWithRegion("ChildRegion", typeof(ViewB));
    var region = _regionManager.Regions["ContentRegion"];
    var view1 = containerProvider.Resolve<ViewA>();
    region.Add(view1);
    region.Activate(view1);
    var view2 = containerProvider.Resolve<ViewA>();
    region.Add(view2);
    region.Activate(view2);
}
```

- So here, we have registered a region with name ChildRegion. 
- Then we are creating two instances of **ViewA**. And ViewA has ChildRegion in it. 
- So the problem occurs, when we try to create two instances of ViewA and then try to add and activate them.
- Now comment out the following two lines and try to run again.

```cs
    region.Add(view2);
    region.Activate(view2);
```
- The following is the code which creates a region. This creates an entry into the RegionManager called ChildRegion. So when two instances are activated, to entires with the same name will exist, so the exception.
```xml
<ContentControl prism:RegionManager.RegionName="ChildRegion" Margin="15" />
```