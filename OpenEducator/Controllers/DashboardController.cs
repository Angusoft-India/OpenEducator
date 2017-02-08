using System.Web.Mvc;

namespace OpenEducator.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index() {
            ViewBag.Title = "Dashboard";
            return View();
        }
        
    }
}