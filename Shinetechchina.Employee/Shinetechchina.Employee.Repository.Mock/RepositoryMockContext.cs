using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Moq;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Mock;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Repository.Test;

namespace Shinetechchina.Employee.Repository.Mock
{
    public class RepositoryMockContext : ContextBase
    {
        Mock<IDbContext> mock = new Mock<IDbContext>();
        public RepositoryMockContext()
        {
            SetUpMock();
        }

        public override Dictionary<Type, Object> GetRegister()
        {
            return new Dictionary<Type, Object>
            {
                [typeof(IEmployeeRepository)] = mock.Object,
            };
        }

        private void SetUpMock()
        {
            mock.Setup(x => x.Set<EmployeeEntity>()).Returns(
                new FakeDbSet<EmployeeEntity>
                {
                    new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                });
        }
    }
}
