using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shinetechchina.Employee.Repository.Shared.Models;

namespace Shinetechchina.Employee.Repository.Shared
{
    public interface IEmployeeRepository
    {
        EmployeeEntry GetEmployee(string id);
        IEnumerable<EmployeeEntry> GetAllEmployee();
    }
}
