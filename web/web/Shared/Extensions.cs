using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace web.Shared
{
    public static class Extensions
    {
        public static MvcHtmlString BootstrapCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlLabelAttributes = null, object htmlCheckBoxAttributes = null)
        {
            var checkbox = htmlHelper.CheckBoxFor(expression, htmlCheckBoxAttributes);
            var label = htmlHelper.LabelFor(expression);
            string text = Regex.Match(label.ToString(), "(?<=^|>)[^><]+?(?=<|$)").Value;

            var labelTag = new TagBuilder("label");
            labelTag.AddCssClass("checkbox");
            labelTag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlLabelAttributes));
            labelTag.InnerHtml = checkbox.ToString() + text;

            return new MvcHtmlString(labelTag.ToString());
        }
    }
}