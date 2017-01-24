using System.Web;
using System.Web.Optimization;

namespace OpenEducator {
    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {
            
            //Fundamental CSS Bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/normalize.css",
                "~/Content/font-awesome/css/font-awesome.css",
                "~/Content/bulma.css",
                "~/Content/site.css"
            ));
            
            //jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/init").Include(
                "~/Scripts/modernizr.js",
                "~/Scripts/app.js"
            ));
        }
    }
}
