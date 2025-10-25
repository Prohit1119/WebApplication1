using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithEFCF1.Models
{
    public class Products
    {
        public int Id { get; set; }
            public string ProductName { get; set; }

            public int CatId { get; set; }

            public decimal UnitPrice { get; set; }

            public byte[] ProductImage { get; set; }

            public string ProductImageName { get; set; }

            public bool Discontinued { get; set; }

            public Category category { get; set; }



        }
    
}