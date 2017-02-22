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
        public int AddEmployee(EmployeeEntry employee)
        {
            EmployeeEntity employeeEntity = employee.ToEntity();
            employeeEntity = _context.Employees.Add(employeeEntity);
            int affectRows = _context.SaveChanges();
            return affectRows;
        }

        public int DeleteEmployee(string employeeID)
        {
            var empployee = _context.Employees.First(t => t.EmployeeID == employeeID);
            var category = _context.Employees.Remove(empployee);
            return _context.SaveChanges();
        }

        public IEnumerable<EmployeeEntry> GetAllEmployee()
        {
            var employees = _context.Employees.ToList().Select(t => t.ToEntry());
            return employees;
        }

        public EmployeeEntry GetEmployee(string EmployeeID)
        {
            var entity = _context.Employees.FirstOrDefault(t => t.EmployeeID == EmployeeID);
            return entity.ToEntry();
        }

        public int UpdateEmployee(EmployeeEntry employee)
        {
            var entity = _context.Employees.FirstOrDefault(t => t.EmployeeID == employee.EmployeeID);
            entity.Email = employee.Email;
            entity.EmployeeID = employee.EmployeeID;
            entity.FirstName = employee.FirstName;
            entity.LastName = employee.LastName;
            entity.Phone = employee.Phone;
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
