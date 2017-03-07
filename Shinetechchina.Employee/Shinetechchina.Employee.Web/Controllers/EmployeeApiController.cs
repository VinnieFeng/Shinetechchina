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
        private IEmployeeMgr employeeManager;

        public EmployeesController(IEmployeeMgr _service)
        {
            employeeManager = _service;
        }
        // GET: api/Employees
        public IEnumerable<EmployeeViewModel> Get()
        {
            var employeeList = employeeManager.GetAllEmployee();
            var employeeViewList = employeeList.Select(t => new EmployeeViewModel(t));
            return employeeViewList;
        }

        // GET: api/Employees/5
        public EmployeeViewModel Get(string id)
        {
            var employee = employeeManager.GetEmployee(id);
            return new EmployeeViewModel(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public HttpResponseMessage Post(EmployeeViewModel emp)
        {
            employeeManager.AddEmployee(emp.ToModel());
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }

        // PUT: api/Employees/5
        public HttpResponseMessage Put(string id, EmployeeViewModel emp)
        {
            employeeManager.UpdateEmployee(emp.ToModel());
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            employeeManager.DeleteEmployee(id);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}
