using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiddlePartWebAPI.StudentServiceReference;
using ServiceWCF;

namespace MiddlePartWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            var proxy = new BackStudentServiceClient();
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Students
        public void Post([FromBody]string value)
        {
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
