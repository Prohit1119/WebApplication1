using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWithEFCF1.Models;

namespace MVCWithEFCF1.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }

        public int CatDescripation { get; set; }

        public ICollection<Products> products { get; set; }

    }

  
}