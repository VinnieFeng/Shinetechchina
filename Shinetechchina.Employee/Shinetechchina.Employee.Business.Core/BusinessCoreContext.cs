using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Core;
using System;
using System.Collections.Generic;

namespace Shinetechchina.Employee.Business.Core
{



    public class BusinessCoreContext : ContextBase
    {
        private static Employee.Core.IServiceProvider current;

      static  RepositoryCoreContext ctx = ContextDictionary.Get<RepositoryCoreContext>();

        public static  ContextBase RepositoryContext
        {
            get { return ctx; }
            set { ctx = value as RepositoryCoreContext; }
        }
        public BusinessCoreContext(ContextBase repositoryContext)
        {
            ctx = repositoryContext as RepositoryCoreContext;
        }



        public override Dictionary<Type, Type> GetRegister()
        {
            return new Dictionary<Type, Type>
            {
                [typeof(IEmployeeMgr)] = typeof(EmployeeMgr)
            };
        }
    }
}
