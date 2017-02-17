using System;
using System.Collections.Generic;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Repository.Shared.Models;

namespace Shinetechchina.Employee.Repository.Core.Implementation
{
    class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<EmployeeEntry> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public EmployeeEntry GetEmployee(string id)
        {
            throw new NotImplementedException();
        }
    }
}
