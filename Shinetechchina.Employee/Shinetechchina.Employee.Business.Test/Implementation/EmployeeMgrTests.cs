using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shinetechchina.Employee.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Mock;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Business.Shared;
using Moq;

namespace Shinetechchina.Employee.Business.Core.Tests
{
    [TestClass()]
    public class EmployeeMgrTests
    {
        [TestMethod()]
        public void AddEmployeeTest()
        {
            EmployeeModel mockData = new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeEntry>())).Returns(1);

            EmployeeMgr mgr = new EmployeeMgr(mock.Object);
            bool result = mgr.AddEmployee(mockData);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.DeleteEmployee(It.IsAny<string>())).Returns(1);

            EmployeeMgr mgr = new EmployeeMgr(mock.Object);
            bool result = mgr.DeleteEmployee("1");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetAllEmployeeTest()
        {
            List<EmployeeEntry> mockData = new List<EmployeeEntry>() {
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
              };
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.GetAllEmployee()).Returns((mockData));

            EmployeeMgr mgr = new EmployeeMgr(mock.Object);
            IEnumerable<EmployeeModel> result = mgr.GetAllEmployee();
            var resultList = result.ToList();
            mockData.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetEmployeeTest()
        {
            EmployeeEntry mockData = new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.GetEmployee(It.IsAny<string>())).Returns((mockData));

            EmployeeMgr mgr = new EmployeeMgr(mock.Object);
            EmployeeModel result = mgr.GetEmployee("");
            Assert.IsTrue(result.EmployeeID == mockData.EmployeeID
                && result.Email == mockData.Email
                && result.FirstName == mockData.FirstName
                && result.LastName == mockData.LastName
                && result.Phone == mockData.Phone);
        }

        [TestMethod()]
        public void UpdateEmployeeTest()
        {
            EmployeeModel mockData = new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeEntry>())).Returns(1);

            EmployeeMgr mgr = new EmployeeMgr(mock.Object);
            bool result = mgr.UpdateEmployee(mockData);
            Assert.IsTrue(result);
        }
    }
}