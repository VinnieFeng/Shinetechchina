namespace Shinetechchina.Employee.Business.Mock
{
    //public class BusinessMockContext : ContextBase
    //{
    //    public Mock<IEmployeeMgr> mock = new Mock<IEmployeeMgr>();
    //    public BusinessMockContext()
    //    {
    //        SetUpMock();
    //    }
    //    public override Dictionary<Type, Object> GetRegister()
    //    {
    //        return new Dictionary<Type, Object>
    //        {
    //            [typeof(IEmployeeMgr)] = mock.Object,
    //            [typeof(IEmployeeRepository)] = typeof(EmployeeRepository) as Object
    //        };
    //    }
    //    private void SetUpMock()
    //    {
    //        mock.Setup(m => m.GetAllEmployee()).Returns(
    //          (new List<EmployeeModel>() {
    //                new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName1", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
    //                new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName2", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
    //                new EmployeeModel { Email="Email", EmployeeID="EmployeeID", FirstName="FirstName3", Id=Guid.NewGuid(), LastName="LastName", Phone="Phone" },
    //           }).AsEnumerable()
    //           );
    //        mock.Setup(m => m.GetEmployee(It.IsAny<string>())).Returns(
    //                new EmployeeModel { Email = "Email", EmployeeID = "EmployeeID", FirstName = "FirstName1", Id = Guid.NewGuid(), LastName = "LastName", Phone = "Phone" }
    //          );
    //        mock.Setup(m => m.AddEmployee(It.IsAny<EmployeeModel>())).Returns(true);
    //        mock.Setup(m => m.DeleteEmployee(It.IsAny<string>())).Returns(true);
    //        mock.Setup(m => m.UpdateEmployee(It.IsAny<EmployeeModel>())).Returns(true);
    //    }
    //}
}


