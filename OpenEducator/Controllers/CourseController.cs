using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenEducator.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index() {
            return View();
        }
        
        // GET: Course/{name}
        public ActionResult ViewCourse() {
            ViewBag.CourseName = RouteData.Values["name"] as string;
            return View();
        }
    }
}