using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BoxingChampionship.Models;

namespace BoxingChampionship.Controllers
{
    public class PageOfChampionshipController : Controller
    {
        private readonly ChampionshipContext _db = new ChampionshipContext();

        // GET: PageOfChampionship
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetValues(string sidx, string sord, int page, int rows)
        {
            var pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var battles = _db.Battles.Select(
                a => new
                {
                    a.Id,
                    a.AmountOfRounds,
                    a.Date,
                    a.Winner,
                    a.Loser,
                    a.RefereePoints
                });
            int totalRecords = battles.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                battles = battles.OrderByDescending(s => s.Id);
                battles = battles.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                battles = battles.OrderBy(s => s.Id);
                battles = battles.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = battles
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Battle obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Battles.Add(obj);
                    _db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successful";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Battle obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(obj).State = EntityState.Modified;
                    _db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successful";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(int id)
        {
            Battle list = _db.Battles.Find(id);
            _db.Battles.Remove(list ?? throw new ArgumentNullException());
            _db.SaveChanges();
            return "Deleted successfully";
        }
    }
}