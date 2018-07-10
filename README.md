## For Asp.Net MVC these are the nuget packages you need:
* Ninject
* Ninject.Web.Common
* Ninject.Web.Common.WebHost
* Ninject.Web.Mvc5

Most of the magic is done in _ NinjectWebCommon.cs _ file. In that class you can add your bindings like the following:
```
private static void RegisterServices(IKernel kernel)
{
    kernel.Bind<ISomeInterface>().To<SomeImplementation>();
}
```

If you have lot of bindings in your project it may become difficult to implement the above approach. In such instances its best to make use of the NinjectModule, like below:

```
private static void RegisterServices(IKernel kernel)
{
    kernel.Load(Assembly.GetExecutingAssembly());
}
```

Then somewhere in your project you create a class that is derived from NinjectModule, eg.

```
public class RepositoryModule: NinjectModule
{
    public override void Load()
    {
        this.Bind<ISomeInterface>().To<SomeImplementation>();
    }
}
```

__ you can define as many module classes as it fits for the project __


