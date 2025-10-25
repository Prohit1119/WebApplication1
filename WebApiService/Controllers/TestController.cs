using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace WebApiService.Controllers
{
    public class TestController : ApiController
    {
        static List<string> _list = new List<string> {
            "Red","Yellow","Pink","Green","White" };

        [HttpGet]
        public List<string> GetColor()
        {
            return _list;
        }

        [HttpGet]
        public string GetSingleColor(int id)
        {
            return _list[id];
        }

        [HttpPost]
        public void PostColor([FromBody] string color)
        {
            _list.Add(color);
        }

        [HttpPut]
        public void Put([FromBody] string color,int id)
        {
            _list[id] = color;
        }

        [HttpDelete]
        public void DeleteColor(int id)
        {
            _list.RemoveAt(id);
        }

    }
}
