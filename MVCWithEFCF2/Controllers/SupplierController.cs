using MVCWithEFCF2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF2.Controllers
{
    public class SupplierController : Controller
    {

        CompanyDbContext dbcontext=new CompanyDbContext();
        // GET: Supplier
        public ActionResult Index()
        {
            Supplier s1 = new Supplier { Sid = 101, SupplierName = "Ashok Distributors." };
            Supplier s2 = new Supplier { Sid = 102, SupplierName = "Meghna Distributors." };
            Supplier s3 = new Supplier { Sid = 103, SupplierName = "Diamond Distributors." };
            Supplier s4 = new Supplier { Sid = 104, SupplierName = "Prasad Distributors." };
            dbcontext.Suppliers.Add(s1); dbcontext.Suppliers.Add(s2); dbcontext.Suppliers.Add(s3); dbcontext.Suppliers.Add(s4);
            dbcontext.SaveChanges();
            return View(dbcontext.Suppliers);

            
        }
    }
}