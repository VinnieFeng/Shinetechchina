using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Shinetechchina.Employee.Repository.Shared;
using Shinetechchina.Employee.Infrastructure.Logging;


namespace Shinetechchina.Employee.Repository.Core
{
    public class RepositoryCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEmployeeRepository>()
                .ImplementedBy<EmployeeRepository>().LifestyleTransient()
                .Interceptors(new InterceptorReference(typeof(LoggingInterceptor))).First);

            container.Register(Component.For<EmployeeDbContext>().ImplementedBy<EmployeeDbContext>().LifestyleTransient());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleTransient());
        }
    }
}
