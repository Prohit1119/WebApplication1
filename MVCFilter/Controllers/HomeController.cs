using MVCFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVCFilter.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        MVCDBEntities dc=new MVCDBEntities();


        #region ChildOnlyFilter

        public ViewResult DisplayDepts()
        {
            return View(dc.Departments);
        }

        [ChildActionOnly]
        public ViewResult DisplayEmpsByDept(int Did)
        {
            var emps=from E in dc.Employees where E.Did == Did select E;
            return View(emps);
        }
        #endregion
        #region Outputcache

        public ViewResult DisplayCustomer1()
        {
            return View(dc.Customers.ToList());
        }

        [OutputCache(Duration =45,Location =System.Web.UI.OutputCacheLocation.Server)]
        public ViewResult DisplayCustomer2()
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

        [OutputCache(CacheProfile="MyCacheProfile")]
        public ViewResult DisplayCustomers5()
        {
            return View(dc.Customers);
        }



        #endregion

        #region ValidateInputFilter
        public ViewResult GetComments()
        {
            return View();
        }
        [HttpPost,ValidateInput(false)]
        public string GetComments(string txtcomments)
        {
            return txtcomments;
        }

        #endregion

        #region ValidateAntiForgeryTokenFilter
        public ViewResult AddEmployee()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public string AddEmployee(Employee employee)
        {
            employee.Status = true;
            dc.Employees.Add(employee);
            dc.SaveChanges();
            return "Recored Inserted";
        }
        #endregion
        #region HandleError Filter
        public ViewResult DivideNums()
        {
            return View();
        }
        [HttpPost,HandleError]
        public string DivideNums(int num1, int num2)
        {
            int result = num1 / num2;
            return "Result is: " + result;
        }



        #endregion

        [HttpPost,HandleError]
        public ViewResult Show()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

       
    }
}