namespace Shinetechchina.Employee.Repository.Shared
{
    using System;

    public class EmployeeEntry
    {
        public Guid? Id { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool? Married { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
    }
}
