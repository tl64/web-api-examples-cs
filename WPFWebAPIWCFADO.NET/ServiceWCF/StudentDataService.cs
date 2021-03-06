﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServiceWCF
{
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
            const string query = @"insert Students values (@param1,@param2,@param3,@param4)";
            SqlCommand command;
            using (connection)
            {
                connection.Open();
                foreach (Student student in inputStudents)
                {
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("param1", student.FirstName);
                    command.Parameters.AddWithValue("param2", student.LastName);
                    command.Parameters.AddWithValue("param3", student.Email);
                    command.Parameters.AddWithValue("param4", student.PhoneNumber);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
            }
        }

        public void UpdateStudent(int id, Student student)
        {
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    var transaction = connection.BeginTransaction();
            //    var command = connection.CreateCommand();
            //    try
            //    {
            //        command.CommandText =
            //            $"UPDATE Students SET FName={student.FirstName}, LName={student.LastName}, Email = {student.Email}, Phone = {student.PhoneNumber} WHERE StudentID={id}";
            //        command.ExecuteNonQuery();
            //        command.Dispose();
            //        transaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        try
            //        {
            //            transaction.Rollback();
            //            throw ex;
            //        }
            //        catch (Exception exceptionRollback)
            //        {
            //            throw exceptionRollback;
            //        }
            //    }
            //}
        }

        public void RemoveStudent(int id)
        {
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (var command = new SqlCommand($"delete Students where StudentID = {id}", connection))
            //    {
            //        command.ExecuteNonQuery();
            //    }
            //}



            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var transaction = con.BeginTransaction();
                var command = con.CreateCommand();

                try
                {
                    command.CommandText = $"DELETE from Students WHERE StudentID={id}";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    catch (Exception exRollback)
                    {
                        throw exRollback;
                    }
                }
            }


            //using (var connection = new SqlConnection(connectionString))
            //{
            //    const string sqlStatement = "DELETE FROM Students WHERE StudentID = @id";
            //    connection.Open();
            //    var cmd = new SqlCommand(sqlStatement, connection);
            //    cmd.Parameters.AddWithValue("@id", id);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery(); 
            //}
        }
    }
}
