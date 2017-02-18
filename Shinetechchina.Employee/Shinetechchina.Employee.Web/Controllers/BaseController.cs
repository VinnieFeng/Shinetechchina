using Castle.Windsor;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Web.Infrastructure.Installer;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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