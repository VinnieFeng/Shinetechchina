
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetechchina.Employee.Web.Controllers;

namespace Shinetechchina.Employee.Web.Installers
{
    public class AppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EmployeesController>().LifestylePerWebRequest());
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net)
            .WithConfig(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
        }
    }
}