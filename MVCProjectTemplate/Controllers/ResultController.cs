using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectTemplate.Models;
using System.Text;
using System.IO;

namespace MVCProjectTemplate.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEmployee()
        {
            Employee e1 = new Employee { Id = 101, Name = "Scott", Job = "CEO", Salary = 25000, Status = true };
            Employee e2 = new Employee { Id = 102, Name = "Smith", Job = "President", Salary = 22000, Status = true };
            Employee e3 = new Employee { Id = 103, Name = "Parker", Job = "Manager", Salary = 18000, Status = true };
            Employee e4 = new Employee { Id = 104, Name = "John", Job = "Salesman", Salary = 10000, Status = true };
            Employee e5 = new Employee { Id = 105, Name = "David", Job = "Clerk", Salary = 5000, Status = true };
            Employee e6 = new Employee { Id = 106, Name = "Maria", Job = "Analyst", Salary = 12000, Status = true };
            List<Employee> Emps = new List<Employee> { e1, e2, e3, e4, e5, e6 };

            return Json(Emps, JsonRequestBehavior.AllowGet);
        }

        public FileResult DownloadPDF()
        {
            return File("~/Download/paySlip_20233290_July2025.pdf", "paySlip_20233290_July2025.pdf");
        }

        public RedirectResult OpenFaceBook()
        {
            return Redirect("www.facebook.com");
        }
        public string SayHello1()
        {
            return "नमस्ते आप कैसे हैं";
        }
        public ContentResult SayHello()
        {
            return Content("नमस्ते आप कैसे हैं", "text/plain", Encoding.UTF8);
        }

        public JavaScriptResult AlertUser()
        {
            return JavaScript("alert('Hello, how are you.');");
        }
        public void ReturnEmpty1()
        {
            string str = ("Hello World").ToUpper();
        }
        public EmptyResult ReturnEmpty2()
        {
            return new EmptyResult();
        }

    }
}