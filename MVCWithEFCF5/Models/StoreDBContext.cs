using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWithEFCF5.Models
{
    public class StoreDBContext:DbContext
    {
        public StoreDBContext() : base("ConDB")
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}