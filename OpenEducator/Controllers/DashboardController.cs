using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static OpenEducator.App_Start.DataProvider;

namespace OpenEducator.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index() {
            ViewBag.Title = "Dashboard";
            return View();
        }

        public ActionResult Test() {
            ViewBag.Title = "Playground";
            return View();
        }
        
    }
}