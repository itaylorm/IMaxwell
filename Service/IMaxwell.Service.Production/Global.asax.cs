using System.Web;
using System.Web.Http;
using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace IMaxwell.Service.Production
{
    public class WebApiApplication : HttpApplication
    {

        private readonly WindsorContainer _container;

        public WebApiApplication()
        {
            _container = new WindsorContainer();
            _container.AddFacility<WcfFacility>();
        }

        protected void Application_Start()
        {

            GlobalConfiguration.Configuration.DependencyResolver = new Core.Windsor.DependencyResolver(_container.Kernel);

            _container.Install(Configuration.FromXmlFile("windsor.xml"));
            _container.Install(FromAssembly.This());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
