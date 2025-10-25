using MVCDataAnnotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataAnnotation.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public JsonResult IsValidDate(DateTime DOB)
        {
            bool status;
            if(DOB>DateTime.Now.AddYears(18))
            {
                status = false;
            }
            else
            {
                status=true;
            }
            return Json(status,JsonRequestBehavior.AllowGet);
        }
        public ViewResult AddUser()
        {
            return View();
        }
        public ViewResult DisplayUser(User user)
        {
            return View(user);
        }

    }
}