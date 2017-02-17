using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shinetechchina.Employee.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}