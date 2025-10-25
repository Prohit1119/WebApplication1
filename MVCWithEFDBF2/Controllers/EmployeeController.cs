using MVCWithEFDBF2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFDBF2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        MVCDBEntities dbenities = new MVCDBEntities();

        public ViewResult EmployeeDisplay()
        {
            var Emp = dbenities.Employees.Where(x => x.Status == true);
            return View(Emp);
        }

        public ViewResult EmployeeDisplayWithId(int ID)
        {
            var singleEmp=dbenities.Employees.Where(x => x.Eid == ID);
            return View(singleEmp);
        }

        public ViewResult AddEmployee()
        {
            ViewBag.Did = new SelectList(dbenities.Departments, "Did", "Dname");
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddEmployee(Employee emp)
        {
            emp.Status = true;
            dbenities.Employees.Add(emp);
            dbenities.SaveChanges();
            return RedirectToAction("EmployeeDisplay");
        }


        public ViewResult EditEmployee(int id)
        {
            Employee emp = dbenities.Employees.Find(id);
            ViewBag.Did = new SelectList(dbenities.Departments, "Did", "Dname", emp.Did);
            return View(emp);
        }

        [HttpPost]
        public RedirectToRouteResult UpdateEmployee(Employee emp)
        {
            emp.Status = true;
            dbenities.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            dbenities.SaveChanges();
            return RedirectToAction("EmployeeDisplay");

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}