# Shows how to work with multiple shells.
- Thisis the starting app for the next example.
- This app nees a bootstrap class.
- So to introduce the bootstrap class do the followng.
  - Add a BootStrapper.cs class 
  - Change the App class to derive from Application rather than PrismApplication. This should be done in both the App.xaml.cs and App.xaml file.
  - So the xaml changes are as follows.
  ```xml
  <prism:PrismApplication x:Class="SimplePrismShell.App"
  >

  </prism:PrismApplication>
  ```
  to the following.
  ```xml
  <Application x:Class="SimplePrismShell.App"
  >
  </Application>
  ```
  - In the App.xaml.cs file, comment out the rest of the code and just override the OnStartup method.
  ```cs
  protected override void OnStartup(StartupEventArgs e)
  {
      base.OnStartup(e);
      var bootstrapper = new BootStrapper();
      bootstrapper.Run();
  }
  ```
  - Now run the app. It should work.