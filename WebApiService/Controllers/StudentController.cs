using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiService.Model;

namespace WebApiService.Controllers
{
    public class StudentController : ApiController
    {
        MVCDBEntities1 mVCDBEntities1=new MVCDBEntities1();

        public List<Student> GetStudents()
        {
            return mVCDBEntities1.Students.ToList();
        }

        public Student Get(int id)
        {
            Student student=mVCDBEntities1.Students.Where(x=>x.Sid==id).FirstOrDefault();
            return student;
            
        }

        [HttpPost]
        public HttpResponseMessage Post(Student student)
        {
            try
            {
                student.Status = true;
                mVCDBEntities1.Students.Add(student);
                mVCDBEntities1.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        public HttpResponseMessage Put(Student student)
        {
            try
            {

           
            Student oldvalue = mVCDBEntities1.Students.Find(student.Sid);
            if(oldvalue==null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            oldvalue.Name= student.Name;
            oldvalue.Class = student.Class;
            oldvalue.Fees = student.Fees;
            oldvalue.Photo = student.Photo;
            mVCDBEntities1.Entry(oldvalue).State = System.Data.EntityState.Modified;
            mVCDBEntities1.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {

               throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
               Student st=mVCDBEntities1.Students.Find(id);
                if(st==null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                st.Status = false;
                mVCDBEntities1.Entry(st).State = System.Data.EntityState.Deleted;
                mVCDBEntities1.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }



    }
}
