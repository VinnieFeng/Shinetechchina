using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Infrastructure.Logging;


namespace Shinetechchina.Employee.Business.Core
{
    public class BusinessCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEmployeeMgr>()
                .ImplementedBy<EmployeeMgr>().LifestyleTransient()
                .Interceptors(new InterceptorReference(typeof(LoggingInterceptor))).First);
        }
    }
}
