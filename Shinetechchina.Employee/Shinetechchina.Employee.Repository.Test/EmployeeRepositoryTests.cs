using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shinetechchina.Employee.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Shinetechchina.Employee.Repository.Mock;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Repository.Test;
using System.Data.Entity;

namespace Shinetechchina.Employee.Repository.Core.Tests
{
    [TestClass()]
    public class EmployeeRepositoryTests
    {
        [TestMethod()]
        public void AddEmployeeTest()
        {
            // Create some test data
            var data = new List<EmployeeEntity>
            {
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
            };

            // Create a mock set and context
            var set = new Mock<DbSet<EmployeeEntity>>().SetupData(data);
            var context = new Mock<EmployeeDbContext>();
            context.Setup(c => c.Employees).Returns(set.Object);

            EmployeeRepository empRepo = new EmployeeRepository(context.Object);
            var mockData = new EmployeeEntry { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" };
            var effectRows = empRepo.AddEmployee(mockData);
            // Check the results
            set.Verify(m => m.Add(It.IsAny<EmployeeEntity>()), Times.Once());
            context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            // Create some test data
            var data = new List<EmployeeEntity>
            {
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
            };

            // Create a mock set and context
            var set = new Mock<DbSet<EmployeeEntity>>().SetupData(data);
            var context = new Mock<EmployeeDbContext>();
            context.Setup(c => c.Employees).Returns(set.Object);

            EmployeeRepository empRepo = new EmployeeRepository(context.Object);
            var effectRows = empRepo.DeleteEmployee("EmployeeID");
            // Check the results
            set.Verify(m => m.Remove(It.IsAny<EmployeeEntity>()), Times.Once());
            context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void GetAllEmployeeTest()
        {
            // Create some test data
            var data = new List<EmployeeEntity>
            {
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
            };

            // Create a mock set and context
            var set = new Mock<DbSet<EmployeeEntity>>().SetupData(data);
            var context = new Mock<EmployeeDbContext>();
            context.Setup(c => c.Employees).Returns(set.Object);

            EmployeeRepository empRepo = new EmployeeRepository(context.Object);
            var resultList = empRepo.GetAllEmployee().ToList();
            // Check the results
            data.ForEach(m => Assert.IsTrue(resultList.Exists(r => r.EmployeeID == m.EmployeeID)));
        }

        [TestMethod()]
        public void GetEmployeeTest()
        {
            // Create some test data
            var data = new List<EmployeeEntity>
            {
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID1", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
                        new EmployeeEntity { Email="Email", EmployeeID="EmployeeID2", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
            };

            // Create a mock set and context
            var set = new Mock<DbSet<EmployeeEntity>>().SetupData(data);
            var context = new Mock<EmployeeDbContext>();
            context.Setup(c => c.Employees).Returns(set.Object);

            EmployeeRepository empRepo = new EmployeeRepository(context.Object);
            var result = empRepo.GetEmployee("EmployeeID1");
            // Check the results
            Assert.IsTrue(result.FirstName== data.First(t=>t.EmployeeID== "EmployeeID1").FirstName);
        }
    }
}