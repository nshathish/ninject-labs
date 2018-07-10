using System.Web.Mvc;

namespace Northwind.Mvc.Controllers
{
  using Core;

  public class HomeController : Controller
  {

    private readonly ICustomerRepository _repository;

    public HomeController(ICustomerRepository repository)
    {
      _repository = repository;
    }

    public ActionResult Index()
    {
      var customers = _repository.GetAll();
      return View(customers);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}