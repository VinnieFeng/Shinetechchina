using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Shinetechchina.Employee.Business.Core;
using Shinetechchina.Employee.Business.Mock;
using Shinetechchina.Employee.Repository.Core;
using Shinetechchina.Employee.Repository.Mock;
using Shinetechchina.Employee.Web.Installers;
using Shinetechchina.Employee.Web.Plumbing;
using Shinetechchina.Employee.Web.Properties;
using Shinetechchina.Employee.Infrastructure;
using Shinetechchina.Employee.Infrastructure.Logging;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppSetUp), "Startup")]
namespace Shinetechchina.Employee.Web.Plumbing
{
    public class AppSetUp
    {
        public static void Startup()
        {
            List<IWindsorInstaller> installers = new List<IWindsorInstaller>() { };
            installers.Add(new AppInstaller());
            installers.Add(new LoggerInstaller());
            if (Settings.Default.IsBusinessMock)
            {
                installers.Add(new BusinessMockInstaller());
            }
            else
            {
                installers.Add(new BusinessCoreInstaller());
            }
            if (Settings.Default.IsRepositoryMock)
            {
                installers.Add(new RepositoryMockInstaller());
            }
            else
            {
                installers.Add(new RepositoryCoreInstaller());
            }
            IoC.Instance.Container.Install(installers.ToArray());
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new WindsorCompositionRoot(IoC.Instance.Container));
        }
    }
}
