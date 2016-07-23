using System.Web.Mvc;

namespace AngularDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AngularDemo()
        {
            ViewBag.Title = "Angular Demo";
            return View();
        }
    }
}
