using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Collections.Generic;
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
                        new EmployeeModel { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName1", Id=Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName="LastName", Phone="Phone" },
                        new EmployeeModel { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName2", Id=Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName="LastName", Phone="Phone" },
                        new EmployeeModel { Email="Email", EmployeeID="EmployeeID3", FirstName="FirstName3", Id=Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName="LastName", Phone="Phone" },
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
            EmployeeModel mockData = new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.GetEmployee(It.IsAny<Guid>())).Returns(
                    new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" }
              );

            var controller = new EmployeesController(mock.Object);
            EmployeeViewModel result = controller.Get(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"));
            Assert.IsNotNull(result);
            Assert.IsTrue(mockData.EmployeeID == result.EmployeeID);
        }

        [TestMethod()]
        public void PostTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeModel>()));

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            controller.Validate(mockData);
            HttpResponseMessage result = controller.Post(mockData);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PutTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeModel>()));

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            controller.Validate(mockData);
            HttpResponseMessage result = controller.Put(mockData.Id.Value, mockData);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.DeleteEmployee(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}")));

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            HttpResponseMessage result = controller.Delete(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"));
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void DeleteTest_ID_InValid()
        {
            Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName = "LastName", Phone = "Phone" };
            mock.Setup(m => m.DeleteEmployee(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}")));

            var controller = new EmployeesController(mock.Object);
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            HttpResponseMessage result = controller.Delete(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"));
            Assert.IsNotNull(result);
        }
    }
}