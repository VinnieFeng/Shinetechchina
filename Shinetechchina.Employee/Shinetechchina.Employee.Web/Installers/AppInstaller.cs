

using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetechchina.Employee.Infrastructure.Logging;
using Shinetechchina.Employee.Web.Controllers;
using Shinetechchina.Employee.Web.Plumbing;
using System.Web.Mvc;

namespace Shinetechchina.Employee.Web.Installers
{
    public class AppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EmployeesController>().LifestylePerWebRequest()
                .Interceptors(new InterceptorReference(typeof(LoggingInterceptor))).First);
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestylePerWebRequest()
                .Configure(x => x.Named(x.Implementation.FullName)));
            container.Register(
             Component.For<IExceptionFilter>().ImplementedBy<JsonErrorFilterAttribute>()
             );
            container.Register(
             Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>()
            );

        }
    }
}