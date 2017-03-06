using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Business.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            EmployeeMgr employeeMgr = new EmployeeMgr(mock.Object);
            bool result = employeeMgr.AddEmployee(mockData);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.DeleteEmployee(It.IsAny<string>())).Returns(1);

            EmployeeMgr employeeMgr = new EmployeeMgr(mock.Object);
            bool result = employeeMgr.DeleteEmployee("1");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetAllEmployeeTest()
        {
            List<EmployeeEntry> mockData = new List<EmployeeEntry>() {
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID3", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
              };
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.GetAllEmployee()).Returns((mockData));

            EmployeeMgr employeeMgr = new EmployeeMgr(mock.Object);
            IEnumerable<EmployeeModel> result = employeeMgr.GetAllEmployee();
            var resultList = result.ToList();
            mockData.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetEmployeeTest()
        {
            EmployeeEntry mockData = new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.GetEmployee("EmployeeID")).Returns((mockData));

            EmployeeMgr employeeMgr = new EmployeeMgr(mock.Object);
            EmployeeModel result = employeeMgr.GetEmployee("EmployeeID");
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

            EmployeeMgr employeeMgr = new EmployeeMgr(mock.Object);
            bool result = employeeMgr.UpdateEmployee(mockData);
            Assert.IsTrue(result);
        }
    }
}