using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Web.Models;

namespace Shinetechchina.Employee.Web.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        private IEmployeeMgr empMgr;

        public EmployeesController(IEmployeeMgr _service)
        {
            empMgr = _service;
        }
        // GET: api/Employees
        public IEnumerable<EmployeeViewModel> Get()
        {
            //var empMgr = Context.GetService<IEmployeeMgr>();
            var employeeList = empMgr.GetAllEmployee();
            var employeeViewList = employeeList.Select(t => new EmployeeViewModel(t));
            return employeeViewList;
        }

        // GET: api/Employees/5
        public EmployeeViewModel Get(string id)
        {
            // var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.GetEmployee(id);
            return new EmployeeViewModel(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public HttpResponseMessage Post(EmployeeViewModel emp)
        {
            //  var empMgr = Context.GetService<IEmployeeMgr>();
            var isSuccess = empMgr.AddEmployee(emp.ToModel());
            return Request.CreateResponse<bool>(System.Net.HttpStatusCode.Created, isSuccess);
        }

        // PUT: api/Employees/5
        public HttpResponseMessage Put(string id, EmployeeViewModel emp)
        {
            // var empMgr = Context.GetService<IEmployeeMgr>();
            var isSuccess = empMgr.UpdateEmployee(emp.ToModel());
            return Request.CreateResponse<bool>(System.Net.HttpStatusCode.OK, isSuccess);
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            //  var empMgr = Context.GetService<IEmployeeMgr>();
            var isSuccess = empMgr.DeleteEmployee(id);
            return Request.CreateResponse<bool>(System.Net.HttpStatusCode.OK, isSuccess);
        }
    }
}
