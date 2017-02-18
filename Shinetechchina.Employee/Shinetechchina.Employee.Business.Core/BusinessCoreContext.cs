using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Core;

using System.Collections.Generic;

namespace Shinetechchina.Employee.Business.Core
{

    public class BusinessOptions
    {
        public bool IsBusinessMock { get; set; }
        public bool IsRepositoryMock { get; set; }
    }

    public class BusinessCoreContext : ContextBase
    {
        private static Employee.Core.IServiceProvider current;



        public ContextBase RepositoryContext { get; set; }
        public BusinessCoreContext(ContextBase repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public BusinessCoreContext(BusinessOptions options)
        {
            //  Options = options;

            if (options.IsRepositoryMock)
            {
                //RepositoryContext = new RepositoryMockContext();
            }
            else
            {
                RepositoryContext = new RepositoryCoreContext();
            }


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
