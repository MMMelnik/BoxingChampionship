using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoxingChampionship.Models;
using BoxingChampionship.ViewModels;

namespace BoxingChampionship.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ChampionshipContext Db = new ChampionshipContext();
        private static List<ChampionshipRankViewModel> _championshipRankViewModels;

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.AmountOfBattlesSortParm = String.IsNullOrEmpty(sortOrder) ? "amountOfBattles_desc" : "";
            ViewBag.RankSortParm = String.IsNullOrEmpty(sortOrder) ? "rank" : "";

            var rankRows = from c in _championshipRankViewModels
                select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                rankRows = rankRows.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "rank":
                    rankRows = rankRows.OrderBy(c => c.CurrentRanking);
                    break;
                case "name":
                    rankRows = rankRows.OrderBy(c => c.Name);
                    break;
                case "amountOfBattles_desc":
                    rankRows = rankRows.OrderByDescending(c => c.AmountOfBattles);
                    break;
                default:
                    rankRows = rankRows.OrderByDescending(c => c.CurrentRanking);
                    break;
            }
            return View(rankRows.ToList());
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
                }).ToList();
        }
    }
}