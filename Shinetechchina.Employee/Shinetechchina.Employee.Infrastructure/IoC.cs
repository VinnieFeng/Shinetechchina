using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Shinetechchina.Employee.Infrastructure.Logging;

namespace Shinetechchina.Employee.Infrastructure
{
    public class IoC
    {
        public static readonly IoC Instance = new IoC();
        public IWindsorContainer Container = new WindsorContainer();

        private IoC()
        {
            Initialize();
        }

        public void Install(params IWindsorInstaller[] installers)
        {
            Container.Install(installers);
        }
        private void Initialize()
        {

            // Add the Array Resolver, so we can take dependencies on T[]
            // while only registering T.
            Container.Kernel.Resolver.AddSubResolver(new ArrayResolver(Container.Kernel));
            // Register the kernel and container, in case an installer needs it.
            Container.Register(
                Component.For<IKernel>().Instance(Container.Kernel),
                Component.For<IWindsorContainer>().Instance(Container)
                );
            Container.Register(Component.For<LoggingInterceptor>());
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }

}
