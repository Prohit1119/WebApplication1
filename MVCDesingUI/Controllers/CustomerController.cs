using MVCDesingUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDesingUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult DisplayCustomer()
        {
            Customer c1 = new Customer
            {
                Custid = 1001,
                Name = "Peter",
                Account = "Savings",
                Balance = 50000.00,
                City = "Delhi",
                Status = true,
                Photo = "/Images/Image1.jpg"
            };
            Customer c2 = new Customer
            {
                Custid = 1002,
                Name = "Kevin",
                Account = "Current",
                Balance = 50000.00,
                City = "Kolkata",
                Status = true,
                Photo = "/Images/Image2.jpg"
            };
            Customer c3 = new Customer
            {
                Custid = 1003,
                Name = "Sandra",
                Account = "Demat",
                Balance = 50000.00,
                City = "Mumabi",
                Status = true,
                Photo = "/Images/Image3.jpg"
            };
            Customer c4 = new Customer
            {
                Custid = 1004,
                Name = "Williams",
                Account = "Savings",
                Balance = 50000.00,
                City = "Chennai",
                Status = true,
                Photo = "/Images/Image4.jpg"
            };
            Customer c5 = new Customer
            {
                Custid = 1005,
                Name = "John",
                Account = "Demat",
                Balance = 50000.00,
                City = "Bengaluru",
                Status = true,
                Photo = "/Images/Image5.jpg"
            };
            Customer c6 = new Customer
            {
                Custid = 1006,
                Name = "Bill",
                Account = "Current",
                Balance = 50000.00,
                City = "Hyderabad",
                Status = true,
                Photo = "/Images/Image6.jpg"
            };

            List<Customer> lst = new List<Customer>() { c1, c2, c3, c4, c5, c6 };
            
           return View(lst);

        }
    }
}