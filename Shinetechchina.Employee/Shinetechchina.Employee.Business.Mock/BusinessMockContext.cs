using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Core;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Business.Mock
{
    public class BusinessMockContext : ContextBase
    {
        public override Dictionary<Type, Type> GetRegister()
        {
            return new Dictionary<Type, Type>
            {
                [typeof(IEmployeeMgr)] = typeof(Mock<IEmployeeMgr>),
                [typeof(IEmployeeRepository)] = typeof(EmployeeRepository)
            };
        }
        Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();

    }
}


