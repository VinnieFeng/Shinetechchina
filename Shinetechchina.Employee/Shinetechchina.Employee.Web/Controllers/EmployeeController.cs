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
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employeeList = empMgr.GetAllEmployee();
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(EmployeeViewModel emp)
        {
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.AddEmployee(emp.ToModel());
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string  empID)
        {
            EmployeeViewModel empModel = new EmployeeViewModel { EmployeeID = empID };
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.DeleteEmployee(new EmployeeModel {  EmployeeID= empID });
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(EmployeeViewModel emp)
        {
            var empMgr = Context.GetService<IEmployeeMgr>();
            var employee = empMgr.UpdateEmployee(emp.ToModel());
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}