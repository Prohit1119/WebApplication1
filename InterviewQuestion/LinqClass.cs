using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion
{
    public class LinqClass
    {
        List<int> Lst=new List<int>{ 1, 2, 3, 2, 4, 5, 1, 6, 3, 3 };
        List<string> LstStr = new List<string> { "Ram", "Face", "Ram", "Tam", "Jam", "TEST" };
         

        public void Duplicated()
        {
            var number = Lst.Where(x => x > 5);
            var evenNumber=Lst.Where(x=>x%2==0);
            var DuplicateList = Lst.Distinct();
            var asc=Lst.OrderBy(x=>x);
            var desc=Lst.OrderByDescending(x=>x);
            var TopSalary = Lst.OrderByDescending(x => x).Take(3);
            int n = 2;
            var nthSalry = Lst.OrderByDescending(e => e).Skip(n - 1).FirstOrDefault();
            var Duplicate = Lst.AsEnumerable().GroupBy(x => x).Where(g => g.Count() > 1);
            var duplicatetst = LstStr.AsEnumerable().GroupBy(x => x).Where(g => g.Count() > 1);
            var dup = LstStr.AsEnumerable().GroupBy(x => x).Where(g => g.Count() > 1).Select(g => new { value = g.Key, count = g.Count() });

            var emp = new[]
            {
                new {Id=1,Name="Ram",Salary=5000,Branch="CS"},
                new {Id=2,Name="Raju",Salary=6000,Branch="IT"},
                new {Id=3,Name="Rahul",Salary=10000,Branch="CS"}
            };

            var Dept = new[]
            {
                new {Id=1,DeptName="HR"},
                new {Id=2,DeptName="Production"}
            };

            List<string> Names = new List<string> { "Rohit", "Rahul", "Permeshwar", null };

            //Top 1st Salary form Employee

            var HighestSalary = emp.AsEnumerable().OrderByDescending(x => x.Salary).Take(1).ToList();

            //Take Second Salary from Employee

            var SecondSalary=emp.AsEnumerable().OrderByDescending(x=>x.Salary).Take(2).ToList();
            var SecondSalaryD = emp.AsEnumerable().OrderByDescending(x => x.Salary).Distinct().Skip(2 - 1).ToList();

            //perform Grouping in LINQ
            var groupdetails = from s in emp
                               group s by s.Branch into g
                               select new { Name = g.Key, Employess = g };
            //performe join 
            var joindetails = from s in emp
                              join d in Dept on s.Id equals d.Id
                              select new { s.Name, d.DeptName };
            //perform how to handle null value in the linq
            var nullhandle = Names.AsEnumerable().Where(x => x != null);

            var sales = new[]
            {
              new { Product = "Mobile", Price = 20000 },
              new { Product = "Laptop", Price = 60000 },
             new { Product = "Mobile", Price = 25000 },
             new { Product = "Laptop", Price = 55000 }
            };

            //group and calculate aggregate (Sum, Count) in LINQ
            var detilas = from s in sales
                          group s by s.Product into g
                          select new
                          {
                              Product = g.Key,
                              sumcount = g.Sum(x => x.Price),
                              count = g.Count()
                          };

            // How to find duplicates in a collection using LINQ

            var names = new List<string> { "Rohit", "Amit", "Rohit", "Neha", "Amit" };

            var duplicate = names.AsEnumerable().GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key);

            //How to convert a List to a Dictionary using LINQ
            
            var dict= emp.ToDictionary(x=>x.Id, x => x.Name);


        }

    }

}
