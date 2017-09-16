using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb
{
    public class HtmlHelpers
    {
        public static HtmlString LocalizedJsBundle(string fileName)
        {
            string culture;
            var cookie = HttpContext.Current.Request.Cookies["lang"];
            if (cookie != null && cookie.Value != null && cookie.Value.Trim() != string.Empty)
                culture = cookie.Value;
            else
                culture = "en-US";
            fileName = string.Concat(fileName, "-", culture);
            var output = (HtmlString)System.Web.Optimization.Scripts.Render(fileName);
            return output;
        }
    }
}