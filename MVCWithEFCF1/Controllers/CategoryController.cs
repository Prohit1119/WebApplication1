using Microsoft.EntityFrameworkCore;
using MVCWithEFCF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        StoreDBContext storeDBContext=new StoreDBContext();

        public ViewResult DisplayCategory()
        {
            var category=storeDBContext.Category.ToList();
            return View(category);
        }

        public ViewResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddCategory(Category category)
        {
            storeDBContext.Category.Add(category);
            storeDBContext.SaveChanges();
            return RedirectToAction("DisplayCategory");
        }

        public ViewResult EditCategory(int CatId)
        {
            Category c = storeDBContext.Category.Find(CatId);
            return View(c);
        }

        [HttpPost]
        public RedirectToRouteResult UpdateCategory(Category c)
        {
           
            storeDBContext.Entry(c).State=EntityState.Modified;
            storeDBContext.SaveChanges();
            return RedirectToAction("DisplayCategory");
        }

        public RedirectToRouteResult DeleteCategory(int CategoryId)
        {
            Category category = storeDBContext.Category.Find(CategoryId);
            storeDBContext.Remove(category);
            storeDBContext.SaveChanges() ;
            return RedirectToAction("DisplayCategory");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}