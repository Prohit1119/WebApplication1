using MVCWithEFCF3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

       StoredDBContext stordDB=new StoredDBContext();
        public ActionResult Index()
        {
            Student s = new Student { Name = "Raju" };
            stordDB.Students.Add(s);
            stordDB.SaveChanges();
            return View();
        }
    }
}