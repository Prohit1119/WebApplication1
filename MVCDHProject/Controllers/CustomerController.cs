using Microsoft.AspNetCore.Mvc;
using MVCDHProject.Models;

namespace MVCDHProject.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataXML dataxml = new CustomerDataXML();

        public ViewResult DisplayCustomer()
        {
            return View(dataxml.Customer_select());
        }

        public ViewResult DisplayCustomerById(int Id)
        {
            return View(dataxml.Customer_Select(Id));
        }

        public ViewResult AddCustomer() {

            return View();
        }
        [HttpPost]
        public RedirectToActionResult AddCustomer(Customer Cust)
        {
            dataxml.Customer_Insert(Cust);
            return RedirectToAction("DisplayCustomer");
        }

        public ViewResult EditCustomer(int Id)
        {
            return View(dataxml.Customer_Select(Id));
        }

        public RedirectToActionResult EditCustomer(Customer Cust)
        {
            dataxml.Customer_Update(Cust);
            return RedirectToAction("DisplayCustomer");
        }

        public RedirectToActionResult DeleteCustomer(int Custid)
        {
            dataxml.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
