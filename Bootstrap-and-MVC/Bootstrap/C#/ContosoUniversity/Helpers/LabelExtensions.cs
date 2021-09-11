using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

// <label class="control-label col-md-2" for="LastName">Last Name</label>

namespace ContosoUniversity.Helpers
{
    public static class LabelExtensions
    {
        public static MvcHtmlString BootstrapLabelFor<TModel, TValue>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes)
        {
            return BootstrapLabelFor(html, expression,
                new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString BootstrapLabelFor<TModel, TValue>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression,
            IDictionary<string, object> htmlAttributes)
        {
            // Label Text
            var metadata = ModelMetadata.FromLambdaExpression(
                expression, html.ViewData);
            var forAttrib = ExpressionHelper.GetExpressionText(
                expression);
            var text = metadata.DisplayName
                       ?? metadata.PropertyName
                       ?? forAttrib.Split('.').Last();
            if (string.IsNullOrEmpty(text))
                return MvcHtmlString.Empty;

            // Label Tag
            var tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.AddCssClass("control-label");
            tag.Attributes.Add("for", html.ViewContext.ViewData.
                TemplateInfo.GetFullHtmlFieldId(forAttrib));
            tag.SetInnerText(text);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}