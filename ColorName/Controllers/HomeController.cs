using Microsoft.AspNetCore.Mvc;

namespace ColorName.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}