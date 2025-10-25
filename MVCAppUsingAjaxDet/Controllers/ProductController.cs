using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using MVCAppUsingAjaxDet.Models;

namespace MVCAppUsingAjaxDet.Controllers
{
    public class ProductController : Controller
    {
        NotrWindEntities notrWind=new NotrWindEntities();
        // GET: Product

        public ViewResult DisplayProduct()
        {
            return View(notrWind.Products);
        }

        [HttpPost]
        public ViewResult SearchProduct(string SearchTerm)
        {
            List<Product> lst=new List<Product>();
            if(SearchTerm.Length==0)
            {
                lst = notrWind.Products.ToList(); 
            }
            else
            {
                lst = notrWind.Products.Where(P => P.ProductName.Contains(SearchTerm)).ToList(); 
            }
            return View("DisplayProduct", lst);
        }

        public JsonResult GetProductDetails(string Term)
        {
            List<Product> products= notrWind.Products.Where(p => p.ProductName.Contains(Term)).ToList();

            return Json(products,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}