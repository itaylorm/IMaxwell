using System.Web.Http;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using IMaxwell.Core.Provider;
using IMaxwell.Data.Core;

namespace IMaxwell.Service.Person.Installers
{
    /// <summary>
    /// Handles WinAPI controller configuration
    /// </summary>
    public class WindsorWebApiInstaller : IWindsorInstaller
    {

        /// <summary>
        /// Registers all the controllers in this project
        /// </summary>
        /// <param name="container">Current windsor container instance</param>
        /// <param name="store">Reference to configuration information for instantiating web api controllers</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped());

            container.Register(
                Component.For<IQueryProvider>()
                    .ImplementedBy(typeof(Data.SqlServer.QueryProvider))
                    .LifestylePerWebRequest()
                    .IsFallback());

            container.Register(
                Component.For<IContactProvider>()
                    .ImplementedBy(typeof(Data.Sql.ContactProvider))
                    .LifestylePerWebRequest()
                    .IsFallback());
        }

    }
}