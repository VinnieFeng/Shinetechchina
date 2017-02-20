using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Business.Shared
{
    public interface IEmployeeMgr
    {
        EmployeeModel GetEmployee(string id);
        IEnumerable<EmployeeModel> GetAllEmployee();
        bool UpdateEmployee(EmployeeModel employee);
        EmployeeModel AddEmployee(EmployeeModel employee);
        bool DeleteEmployee(EmployeeModel employee);
    }
}
