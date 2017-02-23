using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Shinetechchina.Employee.Web.Installers;
using Shinetechchina.Employee.Web.Plumbing;
using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IoC), "Startup")]
namespace Shinetechchina.Employee.Web.Plumbing
{
    public static class IoC
    {
        // Within App_Start components, use:
        // #pragma warning disable 618
        // and :
        // #pragma warning restore 618
        // To temporarily supress this warning.
        [Obsolete("Container should never be accessed directly outside of App_Start")]
        public static IWindsorContainer Container { get; set; }

        public static void Startup()
        {
#pragma warning disable 618
            // Create the container
            Container = new WindsorContainer();

            // Add the Array Resolver, so we can take dependencies on T[]
            // while only registering T.
            Container.Kernel.Resolver.AddSubResolver(new ArrayResolver(Container.Kernel));

            // Register the kernel and container, in case an installer needs it.
            Container.Register(
                Component.For<IKernel>().Instance(Container.Kernel),
                Component.For<IWindsorContainer>().Instance(Container),
                Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>()
                );
            //IFilterProvider
            Container.Register(
                Component.For<IExceptionFilter>().ImplementedBy<JsonErrorFilterAttribute>()
                );

            // Search for an use all installers in this application.
            Container.Install(FromAssembly.InThisApplication());
            Container.Register(Castle.MicroKernel.Registration.Classes.FromThisAssembly()
                .BasedOn<IController>().LifestylePerWebRequest()
                .Configure(x => x.Named(x.Implementation.FullName)));

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new WindsorCompositionRoot(Container));
#pragma warning restore 618
        }
    }
}
