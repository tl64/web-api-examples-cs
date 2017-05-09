using System;

namespace ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentDataService : IBackStudentService
    {

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public string GetStudentByID(int id)
        {
            throw new NotImplementedException();
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
