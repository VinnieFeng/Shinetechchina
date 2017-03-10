using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(Shinetechchina.Employee.Web.Startup))]
namespace Shinetechchina.Employee.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
