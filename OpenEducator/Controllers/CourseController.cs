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

        // GET: NewCourse
        public ActionResult NewCourse() {
            return View();
        }

        // GET: ShowCourse
        public ActionResult ShowCourse() {
            ViewBag.ID = RouteData.Values["id"] ?? "xxx";

            return View();
        }
        
    }
}