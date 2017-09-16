using MusiUploaderWeb.ResourceHandler;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace CodeRepository.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            var croatianValidation = new Bundle(string.Format("~/Scripts/ValidatorNotifications-{0}", "hr-HR"))
                .Include("~/Scripts/ValidationLanguages/messages_hr.js");
            croatianValidation.Transforms.Clear();
            croatianValidation.Transforms.Add(new JSTranslator());
            croatianValidation.Transforms.Add(new JsMinify());
            bundles.Add(croatianValidation);

            BundleTable.EnableOptimizations = false;
        }
    }
}