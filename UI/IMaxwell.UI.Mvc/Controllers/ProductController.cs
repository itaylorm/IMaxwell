using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMaxwell.UI.Mvc.Models;
using IMaxwell.UI.Mvc.Views.Product;

namespace IMaxwell.UI.Mvc.Controllers
{
    public class ProductController : Controller
    {

        /// <summary>
        /// Provides the categories
        /// </summary>
        /// <remarks>GET: /Product/</remarks>
        /// <returns>Returns the categories</returns>
        public ActionResult Index()
        {

            var productCatalog = new ProductCatalog
            {
                Categories = ProductService.GetCategories()
            };

            return View(productCatalog);

        }

        /// <summary>
        /// Provides the sub categories belonging to specified category
        /// </summary>
        /// <remarks>POST: /Product/Category/1</remarks>
        /// <param name="selectedCategoryId">Category unique idenitfier</param>
        /// <returns>Returns sub categories which belong to specified category</returns>
        public ActionResult SelectCategory(int selectedCategoryId)
        {
            var productCatalog = new ProductCatalog
            {
                SelectedCategoryId = selectedCategoryId,
                SubCategories = ProductService.GetSubCategories(selectedCategoryId)
            };

            return View("SubCategoriesUserControl", productCatalog);

        }

        /// <summary>
        /// Provides the products belonging to specified sub category
        /// </summary>
        /// <remarks>POST: /Product/SubCategory/1</remarks>
        /// <param name="selectedSubCategoryId">Category unique idenitfier</param>
        /// <returns>Returns product which belong to specified sub category</returns>
        public ActionResult SelectSubCategory(int selectedSubCategoryId)
        {
            var productCatalog = new ProductCatalog
            {
                SelectedSubCategoryId = selectedSubCategoryId,
                Products = ProductService.GetProducts(selectedSubCategoryId)
            };

            return View("SubCategoriesUserControl", productCatalog);

        }

	}
}