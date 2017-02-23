using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Web.Models;
using Moq;


namespace Shinetechchina.Employee.Web.Controllers.Tests
{
    [TestClass()]
    public class EmployeesControllerTests
    {

        [TestMethod()]
        public void GetTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            List<EmployeeModel> mockData = new List<EmployeeModel>() {
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
              };
            mock.Setup(m => m.GetAllEmployee()).Returns((mockData));

            var controller = new EmployeesController(mock.Object);
            IEnumerable<EmployeeViewModel> result = controller.Get();
            var resultList = result.ToList();
            mockData.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetTest_When_EmployeeID_Is_Valid()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeModel mockData = new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.GetEmployee(It.IsAny<string>())).Returns(
                    new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" }
              );

            var controller = new EmployeesController(mock.Object);
            EmployeeViewModel result = controller.Get("EmployeeID");
            Assert.IsNotNull(result);
            Assert.IsTrue(mockData.EmployeeID == result.EmployeeID);
        }

        [TestMethod()]
        public void PostTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeModel>())).Returns(true);

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            controller.Validate(mockData);
            HttpResponseMessage result = controller.Post(mockData);
            Assert.IsTrue(result.Content.ReadAsStringAsync().Result.ToUpper() == "TRUE");
        }

        [TestMethod()]
        public void PutTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeModel>())).Returns(true);

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            controller.Validate(mockData);
            HttpResponseMessage result = controller.Put(mockData.EmployeeID, mockData);
            Assert.IsTrue(result.Content.ReadAsStringAsync().Result.ToUpper() == "TRUE");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.DeleteEmployee("EmployeeID")).Returns(true);

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            HttpResponseMessage result = controller.Delete("EmployeeID");
            Assert.IsTrue(result.Content.ReadAsStringAsync().Result.ToUpper() == "TRUE");
        }
        [TestMethod()]
        public void DeleteTest_ID_InValid()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.DeleteEmployee("EmployeeID")).Returns(true);

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            HttpResponseMessage result = controller.Delete("EmployeeID3");
            Assert.IsTrue(result.Content.ReadAsStringAsync().Result.ToUpper() == "FALSE");
        }
    }
}