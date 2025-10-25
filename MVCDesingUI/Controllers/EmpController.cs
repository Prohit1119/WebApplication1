using MVCDesingUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDesingUI.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        [HttpGet]
        public ViewResult AddEmp()
            {
            return View();
        }
        [HttpPost]

        public ViewResult AddEmp(Employee employee)
        {
            
            return View("DisplayEmp1",employee);
        }

    }
}
