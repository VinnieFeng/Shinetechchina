using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Shinetechchina.Employee.Core
{
    public interface IServiceProvider
    {
        void Initialize();
        //  bool IsRegistered(Type contract);
        // object GetService(Type contract);
        I GetService<I>();
    }

    public abstract class ContextBase : IServiceProvider//, IDisposable
    {
        private DependencyResolver provider;
       
        protected ContextBase()
        {
            //InitializeWindsor();
        }


        //  public abstract void Initialize();

        public abstract Dictionary<Type, Type> GetRegister();


        public I GetService<I>()
        {
            return (I)provider.GetService(typeof(I));
        }

        public void Initialize()
        {


            WindsorContainer container = new WindsorContainer();
            Dictionary<Type, Type> register = GetRegister();
            IWindsorInstaller installer = new BusinessInstaller(register);
            container.Install(installer);

            provider = new DependencyResolver(container.Kernel);
            
        }
        private class BusinessInstaller : IWindsorInstaller
        {
            Dictionary<Type, Type> register = null;
            public BusinessInstaller(Dictionary<Type, Type> reg)
            {
                register = reg;
            }
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                foreach (var item in register)
                {
                    container.Register(Component.For(item.Key).ImplementedBy(item.Value));
                }

            }


        }
    }
}
