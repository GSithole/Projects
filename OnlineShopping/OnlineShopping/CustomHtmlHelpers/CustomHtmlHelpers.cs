using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShopping.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt,object htmlAttributes)
        {
            TagBuilder tb = new TagBuilder("img");
            RouteValueDictionary htmlAttrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            foreach(var thisAttribute in htmlAttrs)
            {
                tb.Attributes.Add(thisAttribute.Key, thisAttribute.Value.ToString());
            }
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}