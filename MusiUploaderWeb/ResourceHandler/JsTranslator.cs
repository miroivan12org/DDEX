using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;


namespace MusiUploaderWeb.ResourceHandler
{
    public class JSTranslator : IBundleTransform
    {
        #region IBundleTransform

        public void Process(BundleContext context, BundleResponse response)
        {
            string translated = ScriptTranslator(response.Content);
            response.Content = translated;
        }

        #endregion

        #region Localization Of Js Bundle Flow

        private static readonly Regex Regex = new Regex(@"GetResourceValue\(([^\))]*)\)",
                                        RegexOptions.Singleline | RegexOptions.Compiled);

        private string ScriptTranslator(string text)
        {
            MatchCollection matches = Regex.Matches(text);
            foreach (Match match in matches)
            {
                object obj = HttpContext.GetGlobalResourceObject("ValidatorNotifications", match.Groups[1].Value);
                if (obj != null)
                    text = text.Replace(match.Value, CleanText(obj.ToString()));
            }

            return text;
        }

        private static string CleanText(string text)
        {
            text = text.Replace("'", "");
            return text;
        }

        #endregion
    }
}