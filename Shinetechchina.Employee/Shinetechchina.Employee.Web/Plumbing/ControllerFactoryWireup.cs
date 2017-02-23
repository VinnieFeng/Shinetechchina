using System.Web.Mvc;
using Shinetechchina.Employee.Web.Plumbing;
using System.Web.Http.Controllers;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ControllerFactoryWireup), "PostStartup")]
namespace Shinetechchina.Employee.Web.Plumbing
{
    public static class ControllerFactoryWireup
    {
        public static void PostStartup()
        {
#pragma warning disable 618
            var factory = IoC.Container.Resolve<IControllerFactory>();

            ControllerBuilder.Current.SetControllerFactory(factory);

            //var factoryApi = IoC.Container.Resolve<Ih>();

            //ControllerBuilder.Current.SetControllerFactory(factoryApi);

#pragma warning restore 618
        }
    }
}
