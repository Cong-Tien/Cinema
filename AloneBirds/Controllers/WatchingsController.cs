using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AloneBirds.Models;
using AloneBirds.ViewModel;

namespace AloneBirds.Controllers
{
    public class WatchingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Watchings
        public ActionResult Index()
        {
            return View(db.Watchings.ToList());
        }

        // GET: Watchings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watching watching = db.Watchings.Find(id);
            if (watching == null)
            {
                return HttpNotFound();
            }
            return View(watching);
        }

        // GET: Watchings/Create
        public ActionResult Create()
        {
            var viewModel = new WatchingViewModel
            {
                Movies = db.Movies.ToList(),
                ShowTimes = db.ShowTimes.ToList()
            };
            return View(viewModel);
        }

        // POST: Watchings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WatchingViewModel viewModel)
        {
            var watching = new Watching
            {
                MovieId = viewModel.Movie,
                ShowTimeId = viewModel.ShowTime
            };
            db.Watchings.Add(watching);
            db.SaveChanges();
            return RedirectToAction("Index", "Watchings");
        }

        // GET: Watchings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watching watching = db.Watchings.Find(id);
            if (watching == null)
            {
                return HttpNotFound();
            }
            return View(watching);
        }

        // POST: Watchings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShowTimeId,MovieId")] Watching watching)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watching).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(watching);
        }

        // GET: Watchings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watching watching = db.Watchings.Find(id);
            if (watching == null)
            {
                return HttpNotFound();
            }
            return View(watching);
        }

        // POST: Watchings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Watching watching = db.Watchings.Find(id);
            db.Watchings.Remove(watching);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
