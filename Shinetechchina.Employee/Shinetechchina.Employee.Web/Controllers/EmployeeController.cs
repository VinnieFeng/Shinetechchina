using Shinetechchina.Employee.Business.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Shinetechchina.Employee.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {

            var empMgr = Context.GetService<IEmployeeMgr>();
            empMgr.GetAllEmployee();
            return View();
        }
    }
}