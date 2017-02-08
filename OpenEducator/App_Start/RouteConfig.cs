using System.Web.Mvc;
using System.Web.Routing;

namespace OpenEducator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* MAKER CONTROLLER */
            routes.MapRoute(
                name: "Edit Course",
                url: "Maker/Edit/{id}",
                defaults: new { controller = "Maker", action = "Edit" }
            );

            /* COURSE CONTROLLER */
            routes.MapRoute(
                name: "Course List",
                url: "Course",
                defaults: new { controller = "Course", action = "Index" }
            );

            routes.MapRoute(
                name: "Get Course Json",
                url: "Course/{id}/json",
                defaults: new { controller = "Course", action = "CourseJson" }
            );

            routes.MapRoute(
                name: "View Course",
                url: "Course/{id}/{chapter}/{topic}/{page}",
                defaults: new { controller = "Course", action = "ViewCourse", chapter = -1, topic = -1, page = -1 }
            );

            /* DEFAULT FALLBACK */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
