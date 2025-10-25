using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDesingUI.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double? Salary { get; set; }

    }
}