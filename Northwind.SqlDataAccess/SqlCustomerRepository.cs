namespace Northwind.SqlDataAccess
{
  using System.Collections.Generic;
  using System.Linq;
  using Core;

  public class SqlCustomerRepository : ICustomerRepository
  {
    private readonly Mapper _mapper;
    private readonly NorthwindContext _context;

    public SqlCustomerRepository(Mapper mapper, NorthwindContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    public IEnumerable<CustomerEntity> GetAll() => _mapper.Map(_context.Customers);

    public CustomerEntity Get(string id)
    {
      var customer = _context.Customers.SingleOrDefault(c => c.CustomerID == id);
      return _mapper.Map(customer);
    }

    public void Add(CustomerEntity customerEntity)
    {
      var customer = _mapper.Map(customerEntity);
      _context.Customers.Add(customer);
      _context.SaveChanges();
    }
  }
}