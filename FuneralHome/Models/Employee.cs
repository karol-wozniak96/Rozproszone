using MongoDB.Bson.Serialization.Attributes;

namespace FuneralHome.Models
{
    public class Employee
    {
        [BsonElement("employeeId")]
        public int EmployeeId { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        public Employee() { }

        public Employee(int employeeId, string firstName, string lastName, string phoneNumber)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}