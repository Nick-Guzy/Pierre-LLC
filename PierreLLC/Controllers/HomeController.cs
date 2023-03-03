using Microsoft.AspNetCore.Mvc;

namespace PierreLLC.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}