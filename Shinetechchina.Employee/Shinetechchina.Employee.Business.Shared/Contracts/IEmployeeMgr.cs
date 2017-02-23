using System.Collections.Generic;

namespace Shinetechchina.Employee.Business.Shared
{
    public interface IEmployeeMgr
    {
        EmployeeModel GetEmployee(string id);
        IEnumerable<EmployeeModel> GetAllEmployee();
        bool UpdateEmployee(EmployeeModel employee);
        bool AddEmployee(EmployeeModel employee);
        bool DeleteEmployee(string id);
    }
}
