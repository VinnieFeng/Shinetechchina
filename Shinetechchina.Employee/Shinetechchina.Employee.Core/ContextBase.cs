using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.Logging;

namespace Shinetechchina.Employee.Core
{
    public interface IServiceProvider
    {
        void Initialize();
        I GetService<I>();
    }

    public abstract class ContextBase : IServiceProvider//, IDisposable
    {
        private DependencyResolver provider;

        protected ContextBase()
        {
        }

        public abstract Dictionary<Type, Object> GetRegister();

        public I GetService<I>()
        {
            return (I)provider.GetService(typeof(I));
        }

        public void Initialize()
        {
            WindsorContainer container = new WindsorContainer();
            Dictionary<Type, Object> register = GetRegister();
            IWindsorInstaller installer = new BusinessInstaller(register);
            container.Install(installer);
            provider = new DependencyResolver(container.Kernel);
        }
        private class BusinessInstaller : IWindsorInstaller
        {
            Dictionary<Type, Object> register = null;
            public BusinessInstaller(Dictionary<Type, Object> reg)
            {
                register = reg;
            }
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                foreach (var item in register)
                {
                    if (item.Value is Type)
                    {
                        container.Register(Component.For(item.Key).ImplementedBy(item.Value as Type));
                    }
                    else
                    {
                        container.Register(Component.For(item.Key).Instance(item.Value));
                    }
                }
                container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net)
                .WithConfig(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
            }
        }
    }
}
