using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers.Admin
{
    public class HomepageController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
