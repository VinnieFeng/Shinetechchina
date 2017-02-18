using System;

namespace Shinetechchina.Employee.Business.Shared
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool? Married { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
