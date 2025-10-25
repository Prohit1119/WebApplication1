using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCWithLinq2.Models
{
    public class StudentDAL
    {
        MVCDBDataContext db;

        public StudentDAL()
        {
            string Constr = ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString.ToString();
            db = new MVCDBDataContext(Constr);
        }

        public List<Student_SelectResult> GetStudents(bool? Status)
        {
            List<Student_SelectResult> students;
            try
            {
                if (Status != null)
                {
                    students = (from c in db.st where c.Status == Status select c).ToList();
                }
                else
                    students = db.Students.ToList();

                return students;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetStudent(int sid, bool? Status)
        {
            Student student;
            try
            {
                if (Status == null)
                {
                    student = (from c in db.Students where (c.Sid == sid) select c).SingleOrDefault();
                }
                else
                    student = (from S in db.Students where S.Sid == sid && S.Status == Status select S).Single();

                return student;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddStudent(Student student)
        {
            db.Students.InsertOnSubmit(student);
            db.SubmitChanges();
        }

        public void UpdateStudent(Student newvalues)
        {
            try
            {
                Student oldValues = db.Students.Single(s => s.Sid == newvalues.Sid);
                oldValues.Name = newvalues.Name;
                oldValues.Class = newvalues.Class;
                oldValues.Fees = newvalues.Fees;
                oldValues.Photo = newvalues.Photo;
                db.SubmitChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteStudent(int sid)
        {
            try
            {
                Student studentoldvalue = db.Students.First(x => x.Sid == sid);
                studentoldvalue.Status = false;
                //  db.Students.DeleteOnSubmit(studentoldvalue);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}