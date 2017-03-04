using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OpenEducator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() {
            BundleTable.EnableOptimizations = false;

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
