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
        private Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        [TestMethod()]
        public void AddEmployeeTest()
        {
            EmployeeModel mockData = new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            _unitOfWork.Setup(m => m.EmployeeRepository.AddEmployee(It.IsAny<EmployeeEntry>()));
            EmployeeMgr employeeMgr = new EmployeeMgr(_unitOfWork.Object);
            employeeMgr.AddEmployee(mockData);
            _unitOfWork.Verify(m => m.Commit());
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            _unitOfWork.Setup(m => m.EmployeeRepository.DeleteEmployee(It.IsAny<string>()));
            EmployeeMgr employeeMgr = new EmployeeMgr(_unitOfWork.Object);
            employeeMgr.DeleteEmployee("1");
            _unitOfWork.Verify(m => m.Commit());
        }

        [TestMethod()]
        public void GetAllEmployeeTest()
        {
            List<EmployeeEntry> mockData = new List<EmployeeEntry>() {
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeEntry { Email="Email", EmployeeID="EmployeeID3", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
              };
            _unitOfWork.Setup(m => m.EmployeeRepository.GetAllEmployee()).Returns((mockData));
            EmployeeMgr employeeMgr = new EmployeeMgr(_unitOfWork.Object);
            IEnumerable<EmployeeModel> result = employeeMgr.GetAllEmployee();
            var resultList = result.ToList();
            mockData.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetEmployeeTest()
        {
            EmployeeEntry mockData = new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            _unitOfWork.Setup(m => m.EmployeeRepository.GetEmployee("EmployeeID")).Returns((mockData));

            EmployeeMgr employeeMgr = new EmployeeMgr(_unitOfWork.Object);
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
            _unitOfWork.Setup(m => m.EmployeeRepository.UpdateEmployee(It.IsAny<EmployeeEntry>()));

            EmployeeMgr employeeMgr = new EmployeeMgr(_unitOfWork.Object);
            employeeMgr.UpdateEmployee(mockData);
            _unitOfWork.Verify(m => m.Commit());
        }
    }
}