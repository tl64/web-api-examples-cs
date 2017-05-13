using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBackStudentService
    {
        [OperationContract]
        DataTable GetAllStudents();
        [OperationContract]
        DataTable GetStudentByID(int id);
        [OperationContract]
        void AddStudent(IEnumerable<Student> students);
        [OperationContract]
        void UpdateStudent(int id, Student student);
        [OperationContract]
        void RemoveStudent(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceWCF.ContractType".
    [DataContract]
    public class Student
    {
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        [DataMember]
        public string LastName { get; set; } = string.Empty;
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
