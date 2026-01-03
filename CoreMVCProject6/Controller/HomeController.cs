using Microsoft.AspNetCore.Mvc;

namespace CoreMVCProject6.Controllers // Fix: Use 'Controllers' not 'Controller'
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
