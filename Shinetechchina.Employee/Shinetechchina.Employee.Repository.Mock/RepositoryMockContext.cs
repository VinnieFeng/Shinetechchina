using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Mock
{
    public class RepositoryMockContext : ContextBase
    {
        public Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
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
            mock.Setup(m => m.GetAllEmployee()).Returns(
              (new List<EmployeeEntry>() {
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
               }).AsEnumerable()
               );
            mock.Setup(m => m.GetEmployee(It.IsAny<string>())).Returns(
                    new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" }
              );
            mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeEntry>())).Returns(1);
            mock.Setup(m => m.DeleteEmployee(It.IsAny<string>())).Returns(1);
            mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeEntry>())).Returns(1);
        }
    }
}
