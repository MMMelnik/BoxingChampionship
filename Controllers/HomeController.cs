using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using BoxingChampionship.Models;
using BoxingChampionship.ViewModels;
using WebGrease.Css.Ast.Selectors;

namespace BoxingChampionship.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ChampionshipContext Db = new ChampionshipContext();
        private static List<ChampionshipRankViewModel> _championshipRankViewModels;

        public ActionResult Index()
        {
            return View(_championshipRankViewModels);
        }

        public HomeController()
        {
            GenerateRank();
        }

        private static void GenerateRank()
        {
            var battles = Db.Battles.ToList();
            _championshipRankViewModels = battles
                .GroupBy(b => b.Winner)
                .Select(r => new ChampionshipRankViewModel
                {
                    AmountOfBattles = r.Count()+(battles.Count(bt => bt.Loser == r.First().Winner)),
                    Name = r.First().Winner,
                    CurrentRanking = r.Sum(b => b.RefereePoints),
                }).OrderByDescending(cr => cr.CurrentRanking).ToList();
        }
    }
}