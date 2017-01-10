using System.Web;
using System.Web.Optimization;

namespace OpenEducator
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Fundamental CSS Bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/normalize.css",
                "~/Content/broken.css",
                "~/Content/Site.css"
            ));
            //jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            //Foundation
            bundles.Add(new ScriptBundle("~/bundles/broken").Include(
                "~/Scripts/modernizr.js",
                "~/Scripts/broken.js",
                "~/Scripts/app.js"
            ));
        }
    }
}
