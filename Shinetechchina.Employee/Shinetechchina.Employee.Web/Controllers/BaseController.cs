using Shinetechchina.Employee.Core;
using System.Web.Mvc;

namespace Shinetechchina.Employee.Web.Controllers
{
    public class BaseController : Controller
    {
        public IServiceProvider Context { get; set; }
  
        public BaseController()
        {
             Context = ApplicationContext.Current;
          
        }


    }
}