using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetechchina.Employee.Business.Shared;

namespace Shinetechchina.Employee.Business.Core
{
    public   class BusinessCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
             container.Register(Component.For<IEmployeeMgr>().ImplementedBy<EmployeeMgr>().LifestyleTransient());
        }
    }
}
