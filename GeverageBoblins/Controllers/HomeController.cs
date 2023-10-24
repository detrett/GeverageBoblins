using GeverageBoblins.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeverageBoblins.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IActionResult Index()
        {
            return View();
        }

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
