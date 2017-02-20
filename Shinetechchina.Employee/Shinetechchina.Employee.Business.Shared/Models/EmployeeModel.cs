using System;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Business.Shared
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {

        }
        public EmployeeModel(EmployeeEntry entry)
        {
            Email = entry.Email;
            EmployeeID = entry.EmployeeID;
            FirstName = entry.FirstName;
            Id = entry.Id;
            LastName = entry.LastName;
            Phone = entry.Phone;
        }

        public Guid Id { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
                Id = model.Id,
                LastName = model.LastName,
                Phone = model.Phone,
            };
            return entity;
        }

    }

}
