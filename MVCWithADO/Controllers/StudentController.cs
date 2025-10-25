using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithADO.Models;

namespace MVCWithADO.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        StudentDAL obj=new StudentDAL();

        public ViewResult DisplayStudent()
        {
            return View(obj.SelectStudents(null,true));
        }

        public ViewResult GetStudentDetailsById(int Sid)
        {
            return View(obj.SelectStudents(Sid, true).Single());
        }

        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string physicalfile = Server.MapPath("~/Upload/");

                if (!Directory.Exists(physicalfile))
                {
                    Directory.CreateDirectory(physicalfile);
                }
                selectedFile.SaveAs(physicalfile + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            ;
            obj.InsertStudent(student);
            return RedirectToAction("DisplayStudent");

        }

        public ViewResult EditStudent(int sid)
        {
            Student student = obj.SelectStudents(sid, true).Single();
            TempData["Photo"]=student.Photo;
            return View(student);
        }

        [HttpPost]
        public RedirectToRouteResult EditStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string physicalfile=Server.MapPath(selectedFile.FileName);

                if(!Directory.Exists(physicalfile))
                {
                    Directory.CreateDirectory(physicalfile);
                }
                selectedFile.SaveAs(physicalfile+selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            else
            {
                student.Photo = Convert.ToString(TempData["Photo"]);
            }
            obj.UpdateStudent(student);
            return RedirectToAction("DisplayStudent");
        }

        public RedirectToRouteResult DeleteStudent(int sid)
        {
            obj.DeleteStudent(sid);
            return RedirectToAction("DisplayStudent");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}