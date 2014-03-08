using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using IMaxwell.Core.Model;

namespace IMaxwell.Core.Model
{

    /// <summary>
    /// Extension helper methods
    /// </summary>
    public static class Helpers
    {
        public static IHtmlString CurrencyDisplayFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            double value = double.Parse(expression.Compile().Invoke(helper.ViewData.Model).ToString());
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var prop = typeof (TModel).GetProperty(metadata.PropertyName);

            var attribute = prop.GetCustomAttribute(typeof (CurrencyDisplayAttribute)) as CurrencyDisplayAttribute;

            // this should be whatever html element you want to create
            TagBuilder tagBuilder = new TagBuilder("span");
            tagBuilder.SetInnerText(value.ToString("c", CultureInfo.CreateSpecificCulture(attribute.Culture)));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }

}