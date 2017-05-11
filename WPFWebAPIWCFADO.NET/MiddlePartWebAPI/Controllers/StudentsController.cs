using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiddlePartWebAPI.StudentServiceReference;
using Newtonsoft.Json;
using ServiceWCF;

namespace MiddlePartWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        BackStudentServiceClient proxy = new BackStudentServiceClient();
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            var studentsTable = proxy.GetAllStudentsAsync().Result;
            return studentsTable.AsEnumerable().Select(row => new Student
            {
                StudentId = Convert.ToInt32(row["StudentID"]),
                FirstName = row["FName"].ToString(),
                LastName = row["LName"].ToString(),
                Email = row["Email"].ToString(),
                PhoneNumber = row["Phone"].ToString()
            });
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            var student = proxy.GetStudentByIDAsync(id).Result;
            return new Student
            {
                StudentId = Convert.ToInt32(student.Rows[0]["StudentID"]),
                Email = student.Rows[0]["Email"].ToString(),
                FirstName = student.Rows[0]["FName"].ToString(),
                LastName = student.Rows[0]["LName"].ToString(),
                PhoneNumber = student.Rows[0]["Phone"].ToString()
            };
        }

        // POST: api/Students
        public void Post([FromBody]string value)
        {
            var data = (List<Student>)JsonConvert.DeserializeObject(value, typeof(List<Student>));
            proxy.AddStudentAsync(data);
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
        }
    }
}
