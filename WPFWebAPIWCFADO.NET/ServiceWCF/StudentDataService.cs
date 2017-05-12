using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
            var query = $"select * from students where StudentID = {id}";

            var conn = new SqlConnection(connectionString);
            var cmd = new SqlCommand(query, conn);
            using (conn)
            {
                conn.Open();

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(students);
                    //if (id < Convert.ToInt32(students.Rows[0]["StudentID"]) || id > Convert.ToInt32(students.Rows[students.Rows.Count - 1]["StudentID"]))
                    //{
                    //    MessageBox.Show("Entered number is out of bounds");
                    //}
                    return students;
                }
            }
        }

        public void AddStudent(IEnumerable<Student> inputStudents)
        {
            var connection = new SqlConnection(connectionString);
            var query = @"insert Students values (@param1,@param2,@param3,@param4,@param5)";
            var command = new SqlCommand(query,connection);
            using (connection)
            {
                foreach (Student student in inputStudents)
                {
                    command.Parameters.AddWithValue("param1", student.StudentId);
                    command.Parameters.AddWithValue("param2", student.FirstName);
                    command.Parameters.AddWithValue("param3", student.LastName);
                    command.Parameters.AddWithValue("param4", student.Email);
                    command.Parameters.AddWithValue("param5", student.PhoneNumber);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                } 
            }
        }

        public void UpdateStudent(int id)
        {
            //Student s = inputStudents;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand("UPDATE Studentss SET Studentid=@Studentid, FName=@FName, LName=@LName, Email = @Email, Phone = @Phone  WHERE StudentID=@Studentid", connection);
            //    command.Parameters.AddWithValue("StudentID", s.StudentId);
            //    command.Parameters.AddWithValue("FName", s.FirstName);
            //    command.Parameters.AddWithValue("LName", s.LastName);
            //    command.Parameters.AddWithValue("Email", s.Email);
            //    command.Parameters.AddWithValue("Phone", s.PhoneNumber);
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();

            //}
        }

        public void RemoveStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
