using System.Collections.Generic;
using IMaxwell.Core.Model;

namespace IMaxwell.UI.Mvc.Models
{

    /// <summary>
    /// Represents a grouping of products belonging to a category and sub category combination
    /// </summary>
    public class ProductCatalog
    {

        /// <summary>
        /// Selected category identifier
        /// </summary>
        public int SelectedCategoryId { get; set; }
        
        /// <summary>
        /// Selected sub category identifier
        /// </summary>
        public int SelectedSubCategoryId { get; set; }

        /// <summary>
        /// Current categories
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }
        
        /// <summary>
        /// Current sub categories
        /// </summary>
        public IEnumerable<SubCategory> SubCategories { get; set; }
        
        /// <summary>
        /// Current products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

    }
}