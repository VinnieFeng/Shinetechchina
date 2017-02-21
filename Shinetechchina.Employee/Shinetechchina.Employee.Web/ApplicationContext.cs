using Shinetechchina.Employee.Business.Core;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Core;
using Shinetechchina.Employee.Web.Properties;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shinetechchina.Employee.Business.Mock;

namespace Shinetechchina.Employee.Web
{
    public class ApplicationOptions
    {
        public bool IsBusinessMock { get; set; }
        public bool IsRepositoryMock { get; set; }
    }

    public class ApplicationContext : IServiceProvider
    {
        #region Static Members

        private static IServiceProvider current;

        public static IServiceProvider Current
        {
            get
            {
                if (current == null)
                {
                    var options = new ApplicationOptions()
                    {
                        IsBusinessMock = Settings.Default.IsBusinessMock,
                        IsRepositoryMock = Settings.Default.IsRepositoryMock,
                    };

                    current = new ApplicationContext(options);

                    current.Initialize();
                }

                return current;
            }
        }

        #endregion

        public ContextBase BusinessContext { get; set; }
        public ContextBase RepositoryContext { get; set; }
        public ApplicationOptions Options { get; }

        public ApplicationContext(ApplicationOptions options)
        {
            Options = options;

            if (options.IsRepositoryMock)
            {
                //RepositoryContext = new RepositoryMockContext();
            }
            else
            {
                RepositoryContext = new RepositoryCoreContext();
            }

            if (options.IsBusinessMock)
            {
                  BusinessContext = new BusinessMockContext();
            }
            else
            {
                BusinessContext = new BusinessCoreContext(RepositoryContext);
            }
        }

        public T GetService<T>()
        {

            return BusinessContext.GetService<T>();

        }

        public void Initialize()
        {
            RepositoryContext.Initialize();

            BusinessContext.Initialize();
        }

    }
}