using MVCWithLinq3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq3.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeDAL obj=new EmployeeDAL();

        public ViewResult DisplayEmployees()
        {
            return View(obj.GetEmployees(true));
        }
        public ViewResult DisplayEmployee(int eid)
        {
            return View(obj.GetEmloyee(eid, true));
        }

        
        [HttpGet]
        public ViewResult AddEmployee()
        {
            EmpDept emp = new EmpDept();

            emp.Departments = obj.GetDepartment();


            return View(emp);
        }


        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept empDept )
        {
            obj.Employee_Insert(empDept);
            return RedirectToAction("DisplayEmployees");
        }

        public ViewResult EditStudent(int sid)
        {
            EmpDept dept = obj.GetEmloyee(sid,true);
            dept.Departments=obj.GetDepartment();
            return View(dept);

        }

        public RedirectToRouteResult UpdateEmployee(EmpDept emp)
        {
            obj.Employee_Update(emp);
            return RedirectToAction("DisplayEmployees");
        }
        public RedirectToRouteResult DeleteEmployee(int eid)
        {
            obj.Employee_Delete(eid);
            return RedirectToAction("DisplayEmployee");
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}