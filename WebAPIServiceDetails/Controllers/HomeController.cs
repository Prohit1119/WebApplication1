using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIServiceDetails.Controllers
{
    public class HomeController : ApiController
    {
        static List<String> Colors = new List<string>()
        {
          "Red", "Blue", "Green", "Purple", "Magenta"
         };

        //Responds for Get (Select) request
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return Colors;
        }
        //Responds for Get (Select with condition) request with a parameter - id
        [HttpGet]
        public string Get(int id)
        {
            return Colors[id];
        }

        [HttpPost]
        public void Post([FromBody] string data)
        {
            Colors.Add(data);
        }

        public void Put(int id, [FromBody] string color)
        {
            Colors[id] = color;
        }
        //Responds for Delete (Delete) request
        public void Delete(int id)
        {
            Colors.RemoveAt(id);
        }


    }
}
