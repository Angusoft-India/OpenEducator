using Newtonsoft.Json;
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
        
        public ActionResult ViewCourse(string id, string chapter, string topic, string page) {

            try {
                ViewBag.ID = int.Parse(id);
                ViewBag.Chapter = int.Parse(chapter);
                ViewBag.Topic = int.Parse(topic);
                ViewBag.Page = int.Parse(page);
            } catch {
                return HttpNotFound("Invalid Course, Chapter, Topic, or Page ID.");
            }

            return View();
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public JsonResult CourseJson(string id) {
            int nID = 0;

            if(int.TryParse(id, out nID)) {
                return new JsonResult() {
                    Data = Course.GetFromID(nID),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            } else {
                return null;
            }


        }
    }
}