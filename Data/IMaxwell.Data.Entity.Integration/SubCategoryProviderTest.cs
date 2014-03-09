﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Entity.Integration
{
    /// <summary>
    /// Integrated tests for sub category provider
    /// </summary>
    [TestClass]
    public class SubCategoryProviderTest
    {

        /// <summary>
        /// Ensure that sub categories are returned by retrieve list
        /// </summary>
        [TestMethod]
        public void RetrieveCategoriesTest()
        {

            var provider = new SubCategoryProvider();
            var subCategories = provider.Retrieve().ToList();

            Assert.IsNotNull(subCategories);
            Assert.IsTrue(subCategories.Any());

        }

        /// <summary>
        /// Ensure that the sub category provider returns the associated sub categories
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoryTest()
        {

            var provider = new SubCategoryProvider();
            var subCategories = provider.Retrieve(3);

            Assert.IsNotNull(subCategories);
            Assert.IsTrue(subCategories.Any());

        }

    }
}
