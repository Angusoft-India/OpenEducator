using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                name: "View Course",
                url: "Course/{id}/",
                defaults: new { controller = "Course", action = "ViewCourse" }
            );

            routes.MapRoute(
                name: "View Chapter",
                url: "Course/{id}/{chapter}/",
                defaults: new { controller = "Course", action = "ViewChapter" }
            );

            routes.MapRoute(
                name: "View Topic",
                url: "Course/{id}/{chapter}/{topic}/",
                defaults: new { controller = "Course", action = "ViewTopic" }
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
