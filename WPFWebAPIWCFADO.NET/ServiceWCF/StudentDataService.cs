using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentDataService : IBackStudentService
    {
        private const string connectionString = @"data source = (local)\sqlexpress; initial catalog = shopdb; integrated security = true;";

        DataTable students = new DataTable("Students");
        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public DataTable GetAllStudents()
        {
            const string query = "select * from students";

            var conn = new SqlConnection(connectionString);
            var cmd = new SqlCommand(query, conn);
            using (conn)
            {
                conn.Open();

                using (var da = new SqlDataAdapter(cmd))
                {
                    students.Clear();
                    da.Fill(students);
                    return students;
                }
            }
        }

        public DataTable GetStudentByID(int id)
        {
            const string query = "select * from students";

            var conn = new SqlConnection(connectionString);
            var cmd = new SqlCommand(query, conn);
            using (conn)
            {
                conn.Open();

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(students);
                    //if (id < 0 || id > students.Rows.Count) return students.NewRow();
                    var studentRows = students.Select($"StudentID = {id}");
                    foreach (DataRow row in studentRows)
                    {
                            students.ImportRow(row);
                    }
                    return students;
                }
            }
            //var query = $"select * from students where studentid = {id}";

            //var conn = new SqlConnection(connectionString);
            //var cmd = new SqlCommand(query, conn);
            //using (conn)
            //{
            //    conn.Open();

            //    using (var da = new SqlDataAdapter(cmd))
            //    {
            //        students.Clear();
            //        da.Fill(students);
            //        return students;
            //    }
            //}
        }

        public void AddStudent()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
