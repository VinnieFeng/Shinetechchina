using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Business.Shared.Contracts
{
    public interface IEmployeeMgr
    {
        Employee GetEmployee(string ID);
        IEnumerable<Employee> GetAllEmployee();
    }
}
