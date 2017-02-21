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


        RepositoryCoreContext ctx;

        //public static  ContextBase RepositoryContext
        //{
        //    get { return ctx; }
        //    set { ctx = value as RepositoryCoreContext; }
        //}
        public BusinessCoreContext(ContextBase repositoryContext)
        {
            ctx = repositoryContext as RepositoryCoreContext;
        }
        public override Dictionary<Type, Object> GetRegister()
        {
            return new Dictionary<Type, Object>
            {
                [typeof(IEmployeeMgr)] = typeof(EmployeeMgr),
                [typeof(IEmployeeRepository)] = typeof(EmployeeRepository)
            };
        }
        public T GetRepository<T>()
        {
            return ctx.GetService<T>();
        }
    }
}
