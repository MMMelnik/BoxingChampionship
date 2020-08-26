using System.Web.Mvc;

namespace BoxingChampionship.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}