using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Business.Core
{
    class RepositoryFactory
    {
        public override I GetRepository<I>()
        {
            var context = Provider as BusinessCoreContext;

            var result = Provider.GetService<I>();

            result.RepositoryContext = RepositoryContext;

            context.SetServiceFacadeContext(RepositoryContext);

            return result;
        }

        public override I GetService<I>()
        {
            return Provider.GetService<I>();
        }
    }

   
}
