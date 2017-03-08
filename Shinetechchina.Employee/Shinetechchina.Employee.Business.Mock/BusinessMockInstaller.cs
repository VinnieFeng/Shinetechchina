
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Shinetechchina.Employee.Business.Shared;

namespace Shinetechchina.Employee.Business.Mock
{
    public class BusinessMockInstaller : IWindsorInstaller
    {
        public Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
        public BusinessMockInstaller()
        {
            SetUpMock();
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEmployeeMgr>().Instance(mock.Object).LifestyleTransient());
        }

        private void SetUpMock()
        {
            mock.Setup(m => m.GetAllEmployee()).Returns(
              (new List<EmployeeModel>() {
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID3", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
               }).AsEnumerable()
               );
            mock.Setup(m => m.GetEmployee(It.IsAny<Guid>())).Returns(
                    new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID1", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" }
              );
            mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeModel>()));
            mock.Setup(m => m.DeleteEmployee(It.IsAny<Guid>()));
            mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeModel>()));
        }
    }
}


