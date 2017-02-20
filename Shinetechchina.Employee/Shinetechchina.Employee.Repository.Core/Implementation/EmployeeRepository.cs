using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Core
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeEntry AddEmployee(EmployeeEntry employee)
        {
            using (EmployeeDbContext ctx = new EmployeeDbContext())
            {
                EmployeeEntity employeeEntity = employee.ToEntity();
                employeeEntity = ctx.Employees.Add(employeeEntity);
                return employeeEntity.ToEntry();
            }
        }

        public int DeleteEmployee(EmployeeEntry employee)
        {
            using (EmployeeDbContext ctx = new EmployeeDbContext())
            {
                var empployee = ctx.Employees.First(t => t.EmployeeID == employee.EmployeeID);
                var category = ctx.Employees.Remove(empployee);
                return ctx.SaveChanges();
            }
        }

        public IEnumerable<EmployeeEntry> GetAllEmployee()
        {
            using (EmployeeDbContext ctx = new EmployeeDbContext())
            {
                var employees = ctx.Employees.ToList().Select(t => t.ToEntry());
                return employees;
            }

        }

        public EmployeeEntry GetEmployee(string EmployeeID)
        {
            using (EmployeeDbContext ctx = new EmployeeDbContext())
            {
                var entity = ctx.Employees.FirstOrDefault(t => t.EmployeeID == EmployeeID);
                return entity.ToEntry();
            }
        }

        public int UpdateEmployee(EmployeeEntry employee)
        {
            using (EmployeeDbContext ctx = new EmployeeDbContext())
            {
                var entity = ctx.Employees.FirstOrDefault(t => t.EmployeeID == employee.EmployeeID);
                entity = employee.ToEntity();
                ctx.Entry(entity).State = EntityState.Modified;
                return ctx.SaveChanges();
            }
        }
    }
}
