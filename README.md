## For Asp.Net MVC these are the nuget packages you need:
* Ninject
* Ninject.Web.Common
* Ninject.Web.Common.WebHost
* Ninject.Web.Mvc5

Most of the magic is done in _NinjectWebCommon.cs_ file. In that class you can add your bindings like the following:
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

__you can define as many module classes as it fits for the project__

## For Asp.Net WebApi 2, these are the nuget packages you need:
* Ninject
* Ninject.Web.Common
* Ninject.Web.Common.WebHost
* Ninject.Web.WebApi
* Ninject.Web.WebApi.WebHost

Again, _NinjectWebCommon.cs_ handles all the plumbing for you, and bindings could be handled individually in the RegisterServices method in separate NinjectModule derived classes.

__It is very important that the Ninject.Web.WebApi.WebHost package is installed in your Web Api project, otherwise you have to write your own IDependencyResolver implementation__

## For a project that has both MVC and Web Api2, you need the following packages
* Ninject
* Ninject.Web.Common
* Ninject.Web.Common.WebHost
* Ninject.Web.WebApi
* Ninject.Web.WebApi.WebHost
* Ninject.Web.Mvc5

For the Web Api, just make sure _Ninject.Web.WebApi.WebHost_ is installed



