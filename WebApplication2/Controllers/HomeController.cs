using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index1(int? id,string Name,double? price)
        {
            ViewData["id"] = id;
            ViewData["Name"] = Name;

            return View();
        }
        
        public ViewResult Display()
        {
            List<string> Colors = new List<string> { "Red", "Yellow", "Display" };
            ViewData["Colors"] = Colors;
            return View();
        }

        public ActionResult Index2(int? id,string name,double? Price)
        {
            ViewBag.id = id;
            ViewBag.name = name;
            TempData["price"] = Price;

            return RedirectToAction("Index3");
        }

        public ViewResult Index3()
        {
            return View();
        }

        public ActionResult Index4(int? id,string name)
        {
            HttpCookie httpcookie = new HttpCookie("Details");
            httpcookie["Id"]=Convert.ToString(id);
            httpcookie["User"] = name;
            Response.Cookies.Add(httpcookie);
            return View();
        }
        public ActionResult Index5(int? id,string name,double? price)
        {
            Session["id"] = id;
            Session["name"] = name;
            Session["price"] = price;

            return RedirectToAction("Index6");
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7(int? id,string name,double? price)
        {
            HttpContext.Application["Id"] = id;
            HttpContext.Application["name"] = name;
            HttpContext.Application["price"] = price;

            return View();
        }
        public ActionResult Index8()
        {
            return View();
        }
        public ActionResult Index9()
        {
            Product product = new Product()
            {
                Id = 101,
                Name = "Rohit Singh",
                Price = 20202
            };
            return View(product);
        }

        public RedirectToRouteResult Index10(Product product)
        {
            product = new Product { Id = 102, Name = "Rohit Singh", Price = 20202.02 };
            return RedirectToAction("Index2","Test", product);
        }

        
    }
}