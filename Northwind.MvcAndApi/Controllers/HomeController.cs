using System.Web.Mvc;

namespace Northwind.MvcAndApi.Controllers
{
  using Core;

  public class HomeController : Controller
  {
    private readonly ICustomerRepository _customerRepository;

    public HomeController(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }


    public ActionResult Index()
    {
      ViewBag.Title = "Home Page";
      var customers = _customerRepository.GetAll();

      return View(customers);
    }
  }
}
