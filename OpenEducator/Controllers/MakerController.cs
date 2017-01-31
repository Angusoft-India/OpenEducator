using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenEducator.Controllers
{
    public class MakerController : Controller
    {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Edit() {
            ViewBag.ID = RouteData.Values["id"].ToString();

            return View();
        }
    }
}