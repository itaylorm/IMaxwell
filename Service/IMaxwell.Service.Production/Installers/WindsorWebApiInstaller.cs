using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IMaxwell.Core.Provider;

namespace IMaxwell.Service.Production.Installers
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
                Component.For<ICategoryProvider>()
                    .ImplementedBy(typeof(Data.Entity.CategoryProvider))
                    .LifestylePerWebRequest()
                    .IsFallback());

            container.Register(
                Component.For<ISubCategoryProvider>()
                    .ImplementedBy(typeof(Data.Entity.SubCategoryProvider))
                    .LifestylePerWebRequest()
                    .IsFallback());

            container.Register(
                Component.For<IProductProvider>()
                    .ImplementedBy(typeof(Data.Entity.ProductProvider))
                    .LifestylePerWebRequest()
                    .IsFallback());

            container.Register(
                Component.For<IInventoryProvider>()
                    .ImplementedBy(typeof(Data.Entity.InventoryProvider))
                    .LifestylePerWebRequest()
                    .IsFallback());
        }

    }
}