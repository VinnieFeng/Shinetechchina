
using System.Linq;
using System.Web.Mvc;
using Shinetechchina.Employee.Web.Models;
using Shinetechchina.Employee.Business.Shared;

namespace Shinetechchina.Employee.Web.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
        public EmployeeController(IEmployeeMgr service)
        {
        }

        [HandleError]
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

    }
}