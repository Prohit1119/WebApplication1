using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithEFCF1.Models
{
    public class StoreDBContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        
            
        public DbSet<Products> Products { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}