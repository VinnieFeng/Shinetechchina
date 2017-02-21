using System;
using System.Collections.Generic;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Core
{
    public class RepositoryCoreContext : ContextBase
    {


        public override Dictionary<Type, Object> GetRegister()
        {
            return new Dictionary<Type, Object>
            {
                [typeof(IEmployeeRepository)] = typeof(EmployeeRepository)
            };
        }


    }
}
