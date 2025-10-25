using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVCFillterData.Models;

namespace MVCFillterData.Controllers
{
    public class HomeController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();

        #region ChildActionOnly Filter
        public ViewResult DisplayDepts()
        {
            return View(dc.Departments);
        }
        public ViewResult DisplayEmpsByDept(int Did)
        {
            var Emps = from E in dc.Employees where E.Did == Did select E;
            return View(Emps);
        }
        #endregion

        #region OutputCache Filter
        public ViewResult DisplayCustomers1()
        {
            return View(dc.Customers);
        }
        [OutputCache(Duration = 45, Location = OutputCacheLocation.Server)]
        public ViewResult DisplayCustomers2()
        {
            return View(dc.Customers);
        }
        [OutputCache(Duration = 45, Location = OutputCacheLocation.Server, VaryByParam = "City")]
        public ViewResult DisplayCustomers3(string City)
        {
            return View(from C in dc.Customers where C.City == City select C);
        }
        [OutputCache(Duration = 45, Location = OutputCacheLocation.Server, VaryByCustom = "browser")]
        public ViewResult DisplayCustomers4()
        {
            return View(dc.Customers);
        }
        public ViewResult DisplayCustomers5()
        {
            return View(dc.Customers);
        }
        #endregion

        #region ValidateInput Filter
        public ViewResult GetComments()
        {
            return View();
        }
        [HttpPost]
        public string GetComments(string txtComments)
        {
            return txtComments;
        }
        #endregion

        #region ValidateAntiForgeryToken Filter
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public string AddEmployee(Employee Emp)
        {
            Emp.Status = true;
            dc.Employees.Add(Emp);
            dc.SaveChanges();
            return "Record Inserted";
        }
        #endregion

        #region HandleError Filter
        public ViewResult DivideNums()
        {
            return View();
        }
        [HttpPost]
        public string DivideNums(int num1, int num2)
        {
            int result = num1 / num2;
            return "Result is: " + result;
        }
        #endregion
    }


}
