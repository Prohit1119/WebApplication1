using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVCDesingUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        public ViewResult Login()
        {
            return View();
        }

        public ViewResult Validate()
        {
            string username = Request["Username"];
            string password = Request["Password"];
            if (username == "Admin" && password == "password123")
            {
                Session["Name"] = username;
                return View("Success");

            }
            else
            {
                return View("Failure");
            }
        }
    }
}