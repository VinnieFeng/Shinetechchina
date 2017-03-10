using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using log4net;
using log4net.Config;
using System.Reflection;
[assembly: XmlConfigurator(Watch = true)]
namespace Shinetechchina.Employee.Infrastructure.Logging
{

    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log4net.Config.XmlConfigurator.Configure();
            container.Register(Component.For<ILog>().Instance(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)));
            container.Register(Component.For<ILogger>().ImplementedBy<Logger>());
        }
    }
}
