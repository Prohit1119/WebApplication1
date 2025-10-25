using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDesingUI.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProcName { get; set; }

        public string ProcDescription { get; set; } = string.Empty; 

        public string ProdCountry { get; set; }

        public string ProductClass { get; set; }

        public double ProductPrice {  get; set; }
    }
}