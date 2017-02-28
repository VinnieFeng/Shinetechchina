using System;
using System.Linq;
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

        public bool AddEmployee(EmployeeModel employee)
        {
            var emp = employee.ToEntry();
            emp.EmployeeID = $"E{DateTime.Now.Ticks.ToString()}";//mock emplouyee ID
            emp.Created = DateTime.Now;
            emp.Modified = DateTime.Now;
            emp.Id = Guid.NewGuid();
            int insertRowsCount = _employeeRepository.AddEmployee(emp);
            return insertRowsCount == 1;
        }

        public bool DeleteEmployee(string employeeID)
        {
            if (string.IsNullOrEmpty(employeeID))
            {
                throw new ArgumentNullException(nameof(employeeID));
            }
            int effectRows = _employeeRepository.DeleteEmployee(employeeID);
            return effectRows > 0;
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            var empEntity = _employeeRepository.GetAllEmployee().Select(t => new EmployeeModel(t));
            return empEntity;
        }

        public EmployeeModel GetEmployee(string employeeID)
        {
            if (string.IsNullOrEmpty(employeeID))
            {
                throw new ArgumentNullException(nameof(employeeID));
            }
            var empEntity = _employeeRepository.GetEmployee(employeeID);
            return new EmployeeModel(empEntity);
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            var emp = employee.ToEntry();
            emp.Modified = DateTime.Now;
            int effectRows = _employeeRepository.UpdateEmployee(emp);
            return effectRows > 0;
        }
    }
}
