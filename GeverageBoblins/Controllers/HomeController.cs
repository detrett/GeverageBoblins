using Microsoft.AspNetCore.Mvc;

namespace GeverageBoblins.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
