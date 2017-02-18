using System;
using System.Collections.Generic;
using Shinetechchina.Employee.Business.Shared;

namespace Shinetechchina.Employee.Business.Core
{
    public class EmployeeMgr : IEmployeeMgr
    {
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            BusinessCoreContext.RepositoryContext.
        }

        public EmployeeModel GetEmployee(string ID)
        {
            throw new NotImplementedException();
        }
    }
}
