using Shinetechchina.Employee.Business.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Shinetechchina.Employee.Web.Models;

namespace Shinetechchina.Employee.Web.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
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
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employeeList = empMgr.GetAllEmployee();
            var employeeViewList = employeeList.Select(t => new EmployeeViewModel(t));
            return Json(employeeViewList, JsonRequestBehavior.AllowGet);
        }

        [JsonException]
        [HttpPost]
        public JsonResult Add(EmployeeViewModel emp)
        {
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.AddEmployee(emp.ToModel());
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [JsonException]
        [HttpPost]
        public JsonResult Delete(string empID)
        {
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.DeleteEmployee(empID);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [JsonException]
        [HttpPost]
        public JsonResult Update(EmployeeViewModel emp)
        {
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.UpdateEmployee(emp.ToModel());
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}