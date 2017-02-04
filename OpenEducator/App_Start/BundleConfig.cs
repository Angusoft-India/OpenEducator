using System.Web;
using System.Web.Optimization;

namespace OpenEducator {
    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {

            //Fundamental CSS Bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/normalize.css",
                "~/Content/font-awesome/css/font-awesome.css",
                "~/Content/foundation.css",
                "~/Content/contentStyles.css",
                "~/Content/site.css"
            ));

            //jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/init").Include(
                "~/Scripts/modernizr.js",
                "~/Scripts/what-input.js",
                "~/Scripts/foundation.js",
                "~/Scripts/app.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/react").Include(
                "~/Scripts/react/react.js",
                //"~/Scripts/react/react-with-addons.js",
                "~/Scripts/react/react-dom.js",
                "~/Scripts/react/react-dom-server.js"
            ));
            
        }
    }
}
