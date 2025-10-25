using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCWithLinq3.Models
{
    public class EmployeeDAL
    {
        MVCDBDataContext db;
        public EmployeeDAL()
        {
           string ConStr = ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString;
            db=new MVCDBDataContext(ConStr);
        }

        public List<SelectListItem> GetDepartment()
        {
            List<SelectListItem> Dept = new List<SelectListItem>();
            foreach (var item in db.Departments)
            {
                SelectListItem li = new SelectListItem { Text = item.Dname, Value = item.Did.ToString() };
                Dept.Add(li);
            }
            return Dept;
        }

        public EmpDept GetEmloyee(int Sid,bool? Status)
        {
            dynamic Recored;
            if (Status == null)
            {
                Recored = (from C in db.Employees
                           join D in db.Departments on C.Did equals D.Did
                           where C.Eid == Sid
                           select
                        new { C.Eid, C.Ename, C.Job, C.Salary, D.Did, D.Dname, D.Location }).Single();
            }
            else
            {
                Recored = (from C in db.Employees
                           join D in db.Departments on C.Did equals D.Did
                           where C.Eid == Sid && C.Status== Status
                           select
                        new { C.Eid, C.Ename, C.Job, C.Salary, D.Did, D.Dname, D.Location }).Single();
            }

            EmpDept Emp = new EmpDept
            {
                Eid = Recored.Eid,
                Ename = Recored.Name,
                Job = Recored.Job,
                Salary = Recored.Salary,
                Did = Recored.Did,
                Dname = Recored.Dname,
                Location = Recored.Location

            };

            return Emp;

        }

        public List<EmpDept> GetEmployees(bool? Status)
        {
            List<EmpDept> empDepts = new List<EmpDept>();
            dynamic Record;
            if (Status == null)
            {
                Record = (from C in db.Employees
                           join D in db.Departments on C.Did equals D.Did
                           
                           select
                        new { C.Eid, C.Ename, C.Job, C.Salary, D.Did, D.Dname, D.Location }).ToList();
            }
            else
            {
                Record = (from C in db.Employees
                           join D in db.Departments on C.Did equals D.Did
                           where  C.Status == Status
                           select
                        new { C.Eid, C.Ename, C.Job, C.Salary, D.Did, D.Dname, D.Location }).ToList();
            }

            foreach (var item in Record)
            {
                EmpDept empDept = new EmpDept
                {
                    Eid = Convert.ToInt32(Record.Eid),
                    Ename = Record.Ename,
                    Job = Record.Job,
                    Salary = Record.Salary,
                    Did = Record.Did,
                    Dname = Record.Dname,
                    Location = Record.Location
                };
                empDepts.Add(empDept);
            }
            
           return empDepts;
        }

        public void Employee_Insert(EmpDept obj)
        {
            Employee Emp = new Employee
            {
                Ename = obj.Ename,
                Job = obj.Job,
                Salary = obj.Salary,
                Did = obj.Did,
                Status = true
            };
            db.Employees.InsertOnSubmit(Emp);
            db.SubmitChanges();
        }

        public void Employee_Update(EmpDept NewValues)
        {
            Employee OldValues = db.Employees.Single(E => E.Eid == NewValues.Eid);
            OldValues.Ename = NewValues.Ename;
            OldValues.Job = NewValues.Job;
            OldValues.Salary = NewValues.Salary;
            OldValues.Did = NewValues.Did;
            db.SubmitChanges();
        }

        public void Employee_Delete(int Eid)
        {
            Employee OldValues = db.Employees.Single(E => E.Eid == Eid);
            OldValues.Status = false;
            db.SubmitChanges();
        }




    }
}