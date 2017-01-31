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

            string id = RouteData.Values["id"] as string;

            string chap = RouteData.Values["chapter"] as string;
            string topi = RouteData.Values["topic"] as string;
            string page = RouteData.Values["page"] as string;

            ViewBag.Vals = new Dictionary<string, int>() {
                ["ID"] = RetrieveValue(id),
                ["Chapter"] = RetrieveValue(chap),
                ["Topic"] = RetrieveValue(topi),
                ["Page"] = RetrieveValue(page),
            };

            return View();
        }

        public ActionResult ViewChapter() {

            return View();
        }

        public ActionResult ViewTopic() {

            string id = RouteData.Values["id"] as string;

            string chap = RouteData.Values["chapter"] as string;
            string topi = RouteData.Values["topic"] as string;
            string page = RouteData.Values["page"] as string;

            ViewBag.Vals = new Dictionary<string, int>() {
                ["ID"] = RetrieveValue(id),
                ["Chapter"] = RetrieveValue(chap),
                ["Topic"] = RetrieveValue(topi),
                ["Page"] = RetrieveValue(page),
            };

            return View();
        }

        int RetrieveValue(string text, int returnVal = -1) {
            if(string.IsNullOrWhiteSpace(text)) { return returnVal; }
            int val = 0;
            if(!int.TryParse(text, out val)) { return returnVal; }
            return val;
        }
    }
}