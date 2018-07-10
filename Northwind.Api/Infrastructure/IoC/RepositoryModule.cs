namespace Northwind.Api.Infrastructure.IoC
{
  using Core;
  using Ninject.Modules;
  using SqlDataAccess;

  public class RepositoryModule:NinjectModule
  {
    public override void Load()
    {
      this.Bind<ICustomerRepository>().To<SqlCustomerRepository>();
    }
  }
}