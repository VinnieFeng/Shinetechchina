using System.Collections.Generic;

namespace Shinetechchina.Employee.Repository.Shared
{
    public interface IEmployeeRepository
    {
        EmployeeEntry GetEmployee(string id);
        IEnumerable<EmployeeEntry> GetAllEmployee();
        int AddEmployee(EmployeeEntry employee);
        int DeleteEmployee(string employee);
        int UpdateEmployee(EmployeeEntry employee);
    }
}
