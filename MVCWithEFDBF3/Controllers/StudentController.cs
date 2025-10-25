using MVCWithEFDBF3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFDBF3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        MVCDBEntities dc = new MVCDBEntities();

        public ViewResult DisplayResult()
        {
            return View(dc.Student_Select(null,true));
        }
        public ViewResult DisplayStudent(int sid)
        {
            return View(dc.Student_Select(sid, true).Single());
        }
        public ViewResult AddStudent()
        {
            Student_Select_Result student = new Student_Select_Result();
            return View(student);
        }

        [HttpPost]
        public RedirectToRouteResult AddStudent(Student_Select_Result studentT,HttpPostedFileBase httpPostedFile)
        {
            if(httpPostedFile!=null)
            {
                string PhPath = Server.MapPath("~/Upload/");
                if (!Directory.Exists(PhPath))
                {
                    Directory.CreateDirectory(PhPath);
                }
                httpPostedFile.SaveAs(PhPath+httpPostedFile.FileName);
                studentT.Photo = httpPostedFile.FileName;

            }
            dc.Student_Insert(studentT.Sid, studentT.Name, studentT.Class, studentT.Fees, studentT.Photo);
            return RedirectToAction("DisplayResult");
        }

        public ViewResult EditStudent(int Id)
        {
            var student = dc.Student_Select(Id,true).Single();
            TempData["Photo"] = student.Photo;
          
            return View(student);
        }

        [HttpPost]
        public RedirectToRouteResult UpdateStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string PhysicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                    Directory.CreateDirectory(PhysicalPath);
                selectedFile.SaveAs(PhysicalPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            else if (TempData["Photo"] != null)
                student.Photo = TempData["Photo"].ToString();
            dc.Student_Update(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");

        }


        public ActionResult Index()
        {
            return View();
        }
    }
}