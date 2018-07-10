namespace Northwind.Core
{
  using System.Collections.Generic;

  public interface ICustomerRepository
  {
    IEnumerable<CustomerEntity> GetAll();
    CustomerEntity Get(string id);
    void Add(CustomerEntity customer);
  }
}