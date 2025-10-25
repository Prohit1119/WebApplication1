using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Web;

namespace MVCWithADO.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;

        public StudentDAL()
        {
            string constr = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType=System.Data.CommandType.StoredProcedure;

        }

        public List<Student> SelectStudents(int? sid,bool? status)
        {
            List<Student> students = new List<Student>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Select";
                if (sid != null && status != null)
                {
                    cmd.Parameters.AddWithValue("@Sid", sid);
                    cmd.Parameters.AddWithValue("@Status", status);

                }
                else if (sid != null && status == null)
                    cmd.Parameters.AddWithValue("@Sid", sid);
                else if (sid == null && status != null)
                    cmd.Parameters.AddWithValue("@Status", status);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student student = new Student()
                    {
                        Sid = Convert.ToInt32(dr["Sid"]),
                        Name = Convert.ToString(dr["Name"]),
                        Class = Convert.ToInt32(dr["Class"]),
                        Fees = Convert.ToDecimal(dr["Fees"]),
                        Photo = Convert.ToString(dr["Photo"])

                    };
                    students.Add(student);
                }
                }

            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return students;


        }

        public int InsertStudent(Student student)
        {
            int count = 0;
            try
            {
                cmd.CommandText = "Student_Insert";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sid", student.Sid);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                cmd.Parameters.AddWithValue("@Photo", student.Photo);
                con.Open();
                count = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
            finally
            {
                con.Close();
            }

            return count;
        }

        public int UpdateStudent(Student student)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Student_Update";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sid", student.Sid);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                cmd.Parameters.AddWithValue("@Photo", student.Photo);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public int DeleteStudent(int Sid)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Student_Delete";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sid", Sid);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
    }

}
