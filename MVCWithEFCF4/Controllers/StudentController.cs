using MVCWithEFCF4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StoredDBContext dbcontext = new StoredDBContext();

        public ActionResult Index()
        {
            Student s1 = new Student { Name = "Raju", Class = 10, section = "A" };
            Student s2 = new Student { Name = "Venkat", Class = 10, section = "B" };
            Student s3 = new Student { Name = "Srinivas", Class = 10, section = "C" };
            dbcontext.Students.Add(s1); dbcontext.Students.Add(s2); dbcontext.Students.Add(s3);

            return View();
        }
    }
}