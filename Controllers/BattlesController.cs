using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BoxingChampionship.Models;

namespace BoxingChampionship.Controllers
{
    public class BattlesController : Controller
    {
        private readonly ChampionshipContext _db = new ChampionshipContext();

        // GET: Battles
        public ActionResult Index()
        {
            return View(_db.Battles.ToList());
        }

        // GET: Battles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Battle battle = _db.Battles.Find(id);
            if (battle == null)
            {
                return HttpNotFound();
            }
            
            return PartialView("_Details", battle);
        }

        // GET: Battles/Create
        public ActionResult Create()
        {
            return View(new Battle{Date = DateTime.Today.Date});
        }

        // POST: Battles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Winner,Loser,RefereePoints")] Battle battle)
        {
            if (ModelState.IsValid)
            {
                _db.Battles.Add(battle);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(battle);
        }

        // GET: Battles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Battle battle = _db.Battles.Find(id);
            if (battle == null)
            {
                return HttpNotFound();
            }
            return View(battle);
        }

        // POST: Battles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Winner,Loser,RefereePoints")] Battle battle)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(battle).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(battle);
        }

        // GET: Battles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Battle battle = _db.Battles.Find(id);
            if (battle == null)
            {
                return HttpNotFound();
            }
            return View(battle);
        }

        // POST: Battles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Battle battle = _db.Battles.Find(id);
            _db.Battles.Remove(battle ?? throw new InvalidOperationException());
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
