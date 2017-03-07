using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Core
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext ctx)
        {
            _context = ctx;
        }
        public void AddEmployee(EmployeeEntry employee)
        {
            EmployeeEntity employeeEntity = employee.ToEntity();
            employeeEntity = _context.Employees.Add(employeeEntity);
        }

        public void DeleteEmployee(string employeeID)
        {
            var empployee = _context.Employees.First(t => t.EmployeeID == employeeID);
             _context.Employees.Remove(empployee);
        }

        public IEnumerable<EmployeeEntry> GetAllEmployee()
        {
            var employees = _context.Employees.ToList().Select(t => t.ToEntry());
            return employees;
        }

        public EmployeeEntry GetEmployee(string EmployeeID)
        {
            var empployee = _context.Employees.FirstOrDefault(t => t.EmployeeID == EmployeeID);
            return empployee.ToEntry();
        }

        public void UpdateEmployee(EmployeeEntry employee)
        {
            var empployee = _context.Employees.FirstOrDefault(t => t.EmployeeID == employee.EmployeeID);
            empployee.Email = employee.Email;
            empployee.EmployeeID = employee.EmployeeID;
            empployee.FirstName = employee.FirstName;
            empployee.LastName = employee.LastName;
            empployee.Phone = employee.Phone;
            _context.Entry(empployee).State = EntityState.Modified;
        }
    }
}
