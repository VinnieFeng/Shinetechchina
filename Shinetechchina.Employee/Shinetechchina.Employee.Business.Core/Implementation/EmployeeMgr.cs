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

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            var emp = employee.ToEntry();
            var empEntity = _employeeRepository.AddEmployee(emp);
            return new EmployeeModel(empEntity);
        }

        public bool DeleteEmployee(EmployeeModel employee)
        {
            var emp = employee.ToEntry();
            int effectRows = _employeeRepository.DeleteEmployee(emp);
            return effectRows > 0;
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            var empEntity = _employeeRepository.GetAllEmployee().Select(t => new EmployeeModel(t));
            return empEntity;
        }

        public EmployeeModel GetEmployee(string id)
        {
            var empEntity = _employeeRepository.GetEmployee(id);
            return new EmployeeModel(empEntity);
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            int effectRows = _employeeRepository.UpdateEmployee(employee.ToEntry());
            return effectRows > 0;
        }
    }
}
