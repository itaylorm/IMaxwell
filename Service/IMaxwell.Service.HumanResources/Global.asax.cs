using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using Castle.Windsor.Installer;
using IMaxwell.Core.Windsor;

namespace IMaxwell.Service.HumanResources
{
    public class WebApiApplication : HttpApplication
    {

        private readonly WindsorContainer _container;

        public WebApiApplication()
        {
            _container = new WindsorContainer();
            _container.AddFacility<WcfFacility>();
        }

        /// <summary>
        /// Register routes and configuration information
        /// </summary>
        protected void Application_Start()
        {

            GlobalConfiguration.Configuration.DependencyResolver = new Core.Windsor.DependencyResolver(_container.Kernel);

            _container.Install(Configuration.FromXmlFile("windsor.xml"));
            _container.Install(FromAssembly.This());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }




    }
}
