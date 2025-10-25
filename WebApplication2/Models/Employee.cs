using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public bool Status { get; set; }

    }

    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public double? Price { get; set; }
    }
}