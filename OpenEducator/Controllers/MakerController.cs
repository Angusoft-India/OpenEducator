using System.Web.Mvc;

namespace OpenEducator.Controllers
{
    public class MakerController : Controller
    {
        public ActionResult Index() {
            return View();
        }

        public ActionResult TempCreate() {
            return View();
        }
    }
}