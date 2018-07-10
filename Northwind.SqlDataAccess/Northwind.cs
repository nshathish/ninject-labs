namespace Northwind.SqlDataAccess
{
  using System.Data.Entity;

  public class NorthwindContext : DbContext
  {
    public NorthwindContext()
        : base("name=Northwind")
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>()
          .Property(e => e.CustomerID)
          .IsFixedLength();
    }
  }
}
