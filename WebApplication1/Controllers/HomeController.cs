using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mission()
        {
            ViewBag.Messages = "Mission Page";
            return View();
        }
        public ActionResult ConditionContact(int? id) { 
           if(id==null)
            {
                return View("Show1");
            }
           else
            {
                return View("Show2");
            }
        }
    }
}