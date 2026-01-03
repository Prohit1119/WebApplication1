using Microsoft.AspNetCore.Mvc;

namespace MVCCoreTagHelpers1.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }
        public ViewResult Index()
        {
            return View();
        }
        [Route("/Account/Register",Name ="RegisterRoute")]
        public ActionResult Register()
        {
            return View();
        }


    }
}
