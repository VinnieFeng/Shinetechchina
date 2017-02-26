using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Core
{
    public class RepositoryCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEmployeeRepository>().ImplementedBy<EmployeeRepository>().LifestyleTransient());
            container.Register(Component.For<EmployeeDbContext>().ImplementedBy<EmployeeDbContext>().LifestyleTransient());
        }
    }
}
