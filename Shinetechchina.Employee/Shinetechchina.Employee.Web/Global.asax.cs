using Castle.Windsor;
using Castle.Windsor.Installer;
using Shinetechchina.Employee.Web.Infrastructure.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shinetechchina.Employee.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
       // private WindsorContainer _container;

     //  public Infrastructure.Dependency.DependencyResolver d;
        protected void Application_Start()
        {
            //InitializeWindsor();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //private void InitializeWindsor()
        //{
        //    _container = new WindsorContainer();
        //    _container.Install(FromAssembly.This());
        //    _container.Install(new BusinessInstaller());

        //    GlobalConfiguration.Configuration.DependencyResolver = new Infrastructure.Dependency.DependencyResolver(_container.Kernel);
        //    d = new Infrastructure.Dependency.DependencyResolver(_container.Kernel);
        //}
    }
}
