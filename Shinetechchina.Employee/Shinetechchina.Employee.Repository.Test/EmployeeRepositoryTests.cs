using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Moq;
using Shinetechchina.Employee.Repository.Shared;


namespace Shinetechchina.Employee.Repository.Core.Tests
{
    [TestClass()]
    public class EmployeeRepositoryTests
    {
        private Mock<DbSet<EmployeeEntity>> set = null;
        private Mock<EmployeeDbContext> context = null;
        private IUnitOfWork unitOfWork = null;
        List<EmployeeEntity> data = null;

        [TestMethod()]
        public void AddEmployeeTest()
        {
            SetUpMock();
            // Create some test data
            var mockData = new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            // Check the results
            unitOfWork.EmployeeRepository.AddEmployee(mockData);
            unitOfWork.Commit();
            set.Verify(m => m.Add(It.IsAny<EmployeeEntity>()), Times.Once());
            context.Verify(m => m.SaveChanges(), Times.Once()); ;
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            SetUpMock();
            unitOfWork.EmployeeRepository.DeleteEmployee(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"));
            unitOfWork.Commit();
            // Check the results
            set.Verify(m => m.Remove(It.IsAny<EmployeeEntity>()), Times.Once());
            context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void GetAllEmployeeTest()
        {
            // Create a mock set and context
            SetUpMock();
            var resultList = unitOfWork.EmployeeRepository.GetAllEmployee().ToList();
            // Check the results
            data.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetEmployeeTest()
        {
            // Create a mock set and context
            SetUpMock();

            var result = unitOfWork.EmployeeRepository.GetEmployee(Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"));
            // Check the results
            Assert.IsTrue(result.FirstName == "FirstName1");
        }

        private void SetUpMock()
        {
            // Create some test data
            data = new List<EmployeeEntity>
            {
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName1", Id=Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName2", Id=Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID3", FirstName="FirstName3", Id=Guid.Parse("{0F681332-D795-409A-85BB-B77678FB74EE}"), LastName="LastName", Phone="Phone" },
            };

            // Create a mock set and context
            set = new Mock<DbSet<EmployeeEntity>>().SetupData(data);
            context = new Mock<EmployeeDbContext>();
            context.Setup(c => c.Employees).Returns(set.Object);
            unitOfWork = new UnitOfWork(context.Object);
        }
    }
}