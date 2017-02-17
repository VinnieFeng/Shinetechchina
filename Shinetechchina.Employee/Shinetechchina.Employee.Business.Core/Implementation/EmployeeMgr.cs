using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Business.Shared.Contracts;

namespace Shinetechchina.Employee.Business.Core
{
    public class EmployeeMgr : IEmployeeMgr
    {
        public IEnumerable<Shared.Employee> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public Shared.Employee GetEmployee(string ID)
        {
            throw new NotImplementedException();
        }
    }
}
