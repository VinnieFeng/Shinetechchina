using System;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Business.Shared
{
    public class EmployeeModel
    {

        public EmployeeModel(EmployeeEntry entry)
        {
            Email = entry.Email;
            EmployeeID = entry.EmployeeID;
            FirstName = entry.FirstName;
            Gender = entry.Gender;
            Id = entry.Id;
            LastName = entry.LastName;
            Married = entry.Married;
            Phone = entry.Phone;
        }

        public Guid Id { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool? Married { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public static class EmployeeModelExtensions
    {
        public static EmployeeEntry ToEntry(this EmployeeModel model)
        {
            EmployeeEntry entity = new EmployeeEntry()
            {
                Email = model.Email,
                EmployeeID = model.EmployeeID,
                FirstName = model.FirstName,
                Gender = model.Gender,
                Id = model.Id,
                LastName = model.LastName,
                Married = model.Married,
                Phone = model.Phone,
            };
            return entity;
        }

    }

}
