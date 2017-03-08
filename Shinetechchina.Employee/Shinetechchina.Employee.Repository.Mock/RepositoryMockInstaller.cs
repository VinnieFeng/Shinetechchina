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
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        public RepositoryMockInstaller()
        {
            SetUpMock();
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().Instance(mock.Object).LifestyleTransient());
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
            mock.Setup(m => m.EmployeeRepository.AddEmployee(It.IsAny<EmployeeEntry>()));
            mock.Setup(m => m.EmployeeRepository.DeleteEmployee(It.IsAny<Guid>()));
            mock.Setup(m => m.EmployeeRepository.UpdateEmployee(It.IsAny<EmployeeEntry>()));
            mock.Setup(m => m.EmployeeRepository.GetAllEmployee()).Returns(data);
            mock.Setup(m => m.EmployeeRepository.GetEmployee(It.IsAny<Guid>())).Returns(result);
            mock.Setup(m => m.Commit()).Returns(1);
        }
    }
}
