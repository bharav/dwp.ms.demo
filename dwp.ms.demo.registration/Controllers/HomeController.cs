using Microsoft.AspNetCore.Mvc;

namespace dwp.ms.demo.registration.Controllers
{
    public class HomeController: Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
