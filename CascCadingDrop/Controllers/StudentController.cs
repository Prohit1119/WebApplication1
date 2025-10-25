using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascCadingDrop.Models;

namespace CascCadingDrop.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

       private List<Cities> lstCities = new List<Cities>
        {
            new Cities{CitieID=1,CitieName="Nagpur"},
            new Cities{CitieID=2,CitieName="Bihar"},
            new Cities{CitieID=3,CitieName="Varanasi" }
        };

       private List<State> lstState = new List<State>
        {
            new State{StateID=1,StateName="Maharashtra",CitiesId=1},
            new State{StateID=2,StateName="Patna",CitiesId=2},
            new State{StateID=3,StateName="UP",CitiesId=3}
        };
        public ActionResult Index()
        {

            ViewBag.Cities = lstCities;
            return View();
        }

        [HttpGet]
        public JsonResult GetStateName(int countryId)
        {
            var states= lstState.AsEnumerable().Where(x=>x.CitiesId== countryId).ToList();


            return Json(states,JsonRequestBehavior.AllowGet);
        }
    }
}