using Moq;
using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetechchina.Employee.Repository.Shared;


namespace Shinetechchina.Employee.Repository.Mock
{
    public class RepositoryMockInstaller : IWindsorInstaller
    {

        Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
        public RepositoryMockInstaller()
        {
            SetUpMock();
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEmployeeRepository>().Instance(mock.Object).LifestyleTransient());
        }

        private void SetUpMock()
        {

            List<EmployeeEntry> data = new List<EmployeeEntry>
            {
                        new EmployeeEntry { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntry { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntry { Email="Email", EmployeeID="EmployeeID3", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
            };
            EmployeeEntry result = new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID1", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };

            mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeEntry>())).Returns(1);
            mock.Setup(m => m.DeleteEmployee(It.IsAny<string>())).Returns(1);
            mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeEntry>())).Returns(1);
            mock.Setup(m => m.GetAllEmployee()).Returns(data);
            mock.Setup(m => m.GetEmployee(It.IsAny<string>())).Returns(result);
        }
    }
}
