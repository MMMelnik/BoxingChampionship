using System.Web.Mvc;

namespace BoxingChampionship.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageOfChampionship()
        {
            ViewBag.Message = "Page of Championship";

            return View();
        }

        public ActionResult Battle()
        {
            ViewBag.Message = "Page of battle";

            return View();
        }
    }
}