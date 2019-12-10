using Microsoft.AspNetCore.Mvc;

namespace dwp.ms.demo.vehicle.api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}