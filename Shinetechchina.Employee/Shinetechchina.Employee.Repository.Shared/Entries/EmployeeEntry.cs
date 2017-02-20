namespace Shinetechchina.Employee.Repository.Shared
{
    using System;

    public class EmployeeEntry
    {
        public Guid Id { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool? Married { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
    }

    public static class EmployeeEntityExtensions
    {
        public static EmployeeEntity ToEntity(this EmployeeEntry entry)
        {
            EmployeeEntity entity = new EmployeeEntity()
            {
                Email = entry.Email,
                EmployeeID = entry.EmployeeID,
                FirstName = entry.FirstName,
                Gender = entry.Gender,
                Id = entry.Id,
                LastName = entry.LastName,
                Married = entry.Married,
                Phone = entry.Phone,
                Modified = entry.Modified,
                Created = entry.Created
            };
            return entity;
        }
    }

}
