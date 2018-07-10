namespace Northwind.SqlDataAccess
{
  using System.Collections.Generic;
  using System.Linq;
  using Core;

  public class Mapper
  {
    public CustomerEntity Map(Customer customer)
    {
      if (customer == null) return null;

      return new CustomerEntity
      {
        Id = customer.CustomerID,
        City = customer.City,
        CompanyName = customer.CompanyName,
        Phone = customer.Phone,
        PostCode = customer.PostalCode
      };
    }

    public Customer Map(CustomerEntity customer)
    {
      if (customer == null) return null;

      return new Customer
      {
        CustomerID = customer.Id,
        City = customer.City,
        CompanyName = customer.CompanyName,
        Phone = customer.Phone,
        PostalCode = customer.PostCode
      };
    }

    public IEnumerable<CustomerEntity> Map(IEnumerable<Customer> customers)
    {
      return customers.Select(Map);
    }
  }
}