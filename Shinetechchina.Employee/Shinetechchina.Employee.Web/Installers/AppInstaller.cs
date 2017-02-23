
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetechchina.Employee.Business.Core;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Repository.Core;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Web.Controllers;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Shinetechchina.Employee.Web.Installers
{
    public class AppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEmployeeMgr>().ImplementedBy<EmployeeMgr>().LifestyleTransient());
            container.Register(Component.For<IEmployeeRepository>().ImplementedBy<EmployeeRepository>().LifestyleTransient());
            container.Register(Component.For<EmployeeDbContext>().ImplementedBy<EmployeeDbContext>().LifestyleTransient());
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net)
            .WithConfig(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
        }
    }
    public class DependencyConventions : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EmployeesController>().LifestylePerWebRequest());
        }
    }
}