using System;
using System.Collections.Generic;
using System.Data.Entity;
using Moq;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Core;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Mock
{
    public class RepositoryMockContext : ContextBase
    {
   

        // Create a mock set and context
        Mock<DbSet<EmployeeEntity>> set = new Mock<DbSet<EmployeeEntity>>();
        Mock<EmployeeDbContext> context = new Mock<EmployeeDbContext>();
        public RepositoryMockContext()
        {
            SetUpMock();
        }

        public override Dictionary<Type, Object> GetRegister()
        {
            return new Dictionary<Type, Object>
            {
                [typeof(IEmployeeRepository)] = context.Object,
            };
        }

        private void SetUpMock()
        {

            List<EmployeeEntity> data = new List<EmployeeEntity>
            {
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
            };
            set.SetupData(data);
            context.Setup(c => c.Employees).Returns(set.Object);
        }
    }
}
