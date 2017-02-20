using System;
using System.Collections.Generic;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Business.Core
{
    public class EmployeeMgr : IEmployeeMgr
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeMgr(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeModel DeleteEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            //var repo = GetRepository<IEmployeeRepository>();
            //List<EmployeeModel> employeeList = new List<EmployeeModel>();
            //employeeList.Add(new EmployeeModel { Email = "aaa@aaa.com", EmployeeID = "EmployeeID", FirstName = "FirstName", LastName = "LastName", Gender = "Male", Id = Guid.NewGuid(), Married = false, Phone = "Phone" });
            //return employeeList;
            throw new NotImplementedException();
        }

        public EmployeeModel GetEmployee(string ID)
        {
            EmployeeModel employee = new EmployeeModel
            {
                Email = "aaa@aaa.com",
                EmployeeID = "EmployeeID",
                FirstName = "FirstName",
                LastName = "LastName",
                Gender = "Male",
                Id = Guid.NewGuid(),
                Married = false,
                Phone = "Phone"
            };
            return employee;
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
