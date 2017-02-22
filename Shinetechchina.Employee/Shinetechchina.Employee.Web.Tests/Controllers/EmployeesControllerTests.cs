using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shinetechchina.Employee.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web;
using System.Web.Http;
using Shinetechchina.Employee.Business.Mock;
using System.Web.Mvc;
using System.Web.Routing;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Web.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;

namespace Shinetechchina.Employee.Web.Controllers.Tests
{
    [TestClass()]
    public class EmployeesControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            BusinessMockContext ctx = new BusinessMockContext();
            List<EmployeeModel> mockData = new List<EmployeeModel>() {
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                    new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
              };
            ctx.mock.Setup(m => m.GetAllEmployee()).Returns((mockData));
            ctx.Initialize();

            var controller = new EmployeesController();
            controller.Context = ctx;
            IEnumerable<EmployeeViewModel> result = controller.Get();
            var resultList = result.ToList();
            mockData.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetTest_When_EmployeeID_Is_Valid()
        {
            BusinessMockContext ctx = new BusinessMockContext();
            EmployeeModel mockData = new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            ctx.mock.Setup(m => m.GetEmployee(It.IsAny<string>())).Returns(
                    new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" }
              );
            ctx.Initialize();

            var controller = new EmployeesController();
            controller.Context = ctx;
            EmployeeViewModel result = controller.Get("EmployeeID");
            Assert.IsNotNull(result);
            Assert.IsTrue(mockData.EmployeeID == result.EmployeeID);
        }

        [TestMethod()]
        public void PostTest()
        {
            BusinessMockContext ctx = new BusinessMockContext();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email@email.com", EmployeeID = "EmployeeID", FirstName = "FirstName", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            ctx.mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeModel>())).Returns(true);
            ctx.Initialize();

            var controller = new EmployeesController();
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            controller.Context = ctx;
            controller.Validate(mockData);
            HttpResponseMessage result = controller.Post(mockData);
            Assert.IsTrue(result.Content.ReadAsStringAsync().Result.ToUpper()=="TRUE");
        }

        [TestMethod()]
        public void PostTest_When_InValid()
        {
            BusinessMockContext ctx = new BusinessMockContext();
            EmployeeViewModel mockData = new EmployeeViewModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            ctx.mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeModel>())).Returns(true);
            ctx.Initialize();

            var controller = new EmployeesController();
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost/api/employees/")
            };
            controller.Context = ctx;
            controller.Validate(mockData);
            HttpResponseMessage result = controller.Post(mockData);
            Assert.IsTrue(result.Content.ReadAsStringAsync().Result.ToUpper() == "TRUE");
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }



        //      private Mock<ApiController> MockHttpContext()
        //{
        //    var request = new Mock<ApiController>();
        //    request.SetupGet(x => x.Headers).Returns(
        //     new HttpResponseHeaders());


        //   );


        //    return context;
        //}
    }
}