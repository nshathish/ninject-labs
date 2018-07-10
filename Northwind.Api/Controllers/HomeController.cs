using System.Web.Http;

namespace Northwind.Api.Controllers
{
  using Core;

  public class HomeController : ApiController
  {
    private readonly ICustomerRepository _customerRepository;

    public HomeController(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public IHttpActionResult GetCustomers() => Ok(_customerRepository.GetAll());


  }
}
