using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Core;
using System;
using System.Collections.Generic;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Business.Core
{
    public class BusinessCoreContext : ContextBase
    {
        ContextBase ctx;
        public BusinessCoreContext(ContextBase repositoryContext)
        {
            ctx = repositoryContext ;
        }
        public override Dictionary<Type, Object> GetRegister()
        {
            return new Dictionary<Type, Object>
            {
                [typeof(IEmployeeMgr)] = typeof(EmployeeMgr),
                [typeof(IEmployeeRepository)] = typeof(EmployeeRepository),
                [typeof(EmployeeDbContext)] = typeof(EmployeeDbContext)
            };
        }
        public T GetRepository<T>()
        {
            return ctx.GetService<T>();
        }
    }
}
