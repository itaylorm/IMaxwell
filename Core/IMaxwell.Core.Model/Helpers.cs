using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMaxwell.Core.Model
{

    /// <summary>
    /// Extension helper methods
    /// </summary>
    public static class Helpers
    {
        public static IHtmlString CurrencyFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var value = double.Parse(expression.Compile().Invoke(helper.ViewData.Model).ToString());
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var prop = typeof (TModel).GetProperty(metadata.PropertyName);

            var attribute = prop.GetCustomAttribute(typeof (CurrencyDisplayAttribute)) as CurrencyDisplayAttribute;

            // this should be whatever html element you want to create
            var tagBuilder = new TagBuilder("input");

            tagBuilder.Attributes.Add("type", "text");
            if (attribute != null)
                tagBuilder.Attributes.Add("value", value.ToString("c", CultureInfo.CreateSpecificCulture(attribute.Culture)));

            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }

}