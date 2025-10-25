using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCAppUsingAjax.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public string GetScore()
        {
            string file = Server.MapPath("~/Matches/Score.xml");

            var  doc=XElement.Load(file);

            string scroe = doc.Element("Score").Value;

            return scroe;


        }
    }
}