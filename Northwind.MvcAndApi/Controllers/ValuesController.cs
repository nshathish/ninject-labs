using System.Web.Http;

namespace Northwind.MvcAndApi.Controllers
{
  using Core;

  public class ValuesController : ApiController
  {
    private readonly ICustomerRepository _customerRepository;

    public ValuesController(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public IHttpActionResult Get() => Ok(_customerRepository.GetAll());


    // GET api/values/5
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }
  }
}
