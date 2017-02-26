
using System.Linq;
using System.Web.Mvc;
using Shinetechchina.Employee.Web.Models;
using Shinetechchina.Employee.Business.Shared;

namespace Shinetechchina.Employee.Web.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeMgr empMgr;

        public EmployeeController(IEmployeeMgr service)
        {
            empMgr = service;
        }

        [HandleError]
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [JsonException]
        [HttpGet]
        public JsonResult GetAll()
        {
            var employeeList = empMgr.GetAllEmployee();
            var employeeViewList = employeeList.Select(t => new EmployeeViewModel(t));
            return Json(employeeViewList, JsonRequestBehavior.AllowGet);
        }

        [JsonException]
        [HttpPost]
        public JsonResult Add(EmployeeViewModel emp)
        {
            var employee = empMgr.AddEmployee(emp.ToModel());
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [JsonException]
        [HttpPost]
        public JsonResult Delete(string empID)
        {
            var employee = empMgr.DeleteEmployee(empID);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [JsonException]
        [HttpPost]
        public JsonResult Update(EmployeeViewModel emp)
        {
            var employee = empMgr.UpdateEmployee(emp.ToModel());
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}