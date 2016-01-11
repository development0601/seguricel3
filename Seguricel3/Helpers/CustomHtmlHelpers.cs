using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Seguricel3
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString ImageActionLink(this HtmlHelper htmlHelper, string linkText, string action, string controller, object routeValues, object htmlAttributes, string imageSrc, int Height)
        {
            RouteValueDictionary _HtmlAttributes = new RouteValueDictionary(htmlAttributes);
            //KeyValuePair<string, string> OnClick = { "onclick", "$('#loading').fadeIn(100);" };
            if (_HtmlAttributes != null && !_HtmlAttributes.ContainsKey("onclick"))
                _HtmlAttributes.Add("onclick", "$('#loading').fadeIn(100);");
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            img.Attributes.Add("src", VirtualPathUtility.ToAbsolute(imageSrc));
            img.Attributes.Add("height", Height.ToString());
            //if (linkText == "Ingresar" || linkText == "Cerrar Sesión")
            //    img.Attributes.Add("height", "30");
            //else if (linkText == "Nueva" || linkText == "Nuevo")
            //    img.Attributes.Add("height", "20");
            //else if (Height > 0)
            //else
            //    img.Attributes.Add("height", "50");
            var anchor = new TagBuilder("a") { InnerHtml = img.ToString(TagRenderMode.SelfClosing) };
            anchor.Attributes["title"] = linkText;
            anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            anchor.MergeAttributes(_HtmlAttributes);

            return MvcHtmlString.Create(anchor.ToString());
        }
        public static IHtmlString ImageActionLink(this HtmlHelper htmlHelper, string linkText, string action, object routeValues, object htmlAttributes, string imageSrc, int Height)
        {
            RouteValueDictionary _HtmlAttributes = new RouteValueDictionary(htmlAttributes);
            //KeyValuePair<string, string> OnClick = { "onclick", "$('#loading').fadeIn(100);" };
            if (_HtmlAttributes != null && !_HtmlAttributes.ContainsKey("onclick"))
                _HtmlAttributes.Add("onclick", "$('#loading').fadeIn(100);");
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            img.Attributes.Add("src", VirtualPathUtility.ToAbsolute(imageSrc));
            img.Attributes.Add("height", Height.ToString());
            //if (linkText == "Ingresar" || linkText == "Cerrar Sesión")
            //    img.Attributes.Add("height", "30");
            //else if (linkText == "Nueva" || linkText == "Nuevo")
            //    img.Attributes.Add("height", "20");
            //else if (Height > 0)
            //else
            //    img.Attributes.Add("height", "50");
            var anchor = new TagBuilder("a") { InnerHtml = img.ToString(TagRenderMode.SelfClosing) };
            anchor.Attributes["title"] = linkText;
            anchor.Attributes["href"] = urlHelper.Action(action, routeValues);
            anchor.MergeAttributes(_HtmlAttributes);

            return MvcHtmlString.Create(anchor.ToString());
        }

        public static IHtmlString ActionLlinkWithSpan(this HtmlHelper htmlHelper, string linkText, string action, string controller, object routeValues, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var anchor = new TagBuilder("a");
            anchor.InnerHtml = linkText;
            anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(anchor.ToString());
        }
    }
}
