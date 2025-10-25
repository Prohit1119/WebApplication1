using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWithEFCF2.Models
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext():base("ConDB")
        {
                Database.SetInitializer(new DropCreateDatabaseAlways<CompanyDbContext>());
        }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasKey(s => s.Sid);
        }

    }
}