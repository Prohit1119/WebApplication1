using MVCWithEFCF3.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWithEFCF3.Models
{
    public class StoredDBContext:DbContext
    {
        public StoredDBContext():base("ConDB")
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoredDBContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }
    }
}