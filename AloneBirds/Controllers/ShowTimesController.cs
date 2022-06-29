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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AloneBirds.Controllers
{
    public class ShowTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShowTimes
        [Authorize]
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId());
            //ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            if (user.CategoryClient == 1)
            {
                var showtime = db.ShowTimes       
               .Include(l => l.Room).ToList();
                return View(showtime);
            }
            if (user.CategoryClient == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Base");
        }
            // GET: ShowTimes/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTimes = db.ShowTimes.Find(id);
            if (showTimes == null)
            {
                return HttpNotFound();
            }
            return View(showTimes);
        }

        // GET: ShowTimes/Create
        public ActionResult Create()
        {
            var viewModel = new ShowTimesViewModel
            {
                Rooms = db.Rooms.ToList()
            };
            return View(viewModel);
        }

        // POST: ShowTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowTimesViewModel viewModel)
        {
            var showtime = new ShowTime
            {
                DateTime = viewModel.GetDateTime(),
                RoomId = viewModel.Room,
                Fare=(int)viewModel.Fare
            };
            db.ShowTimes.Add(showtime);
            db.SaveChanges();

            return RedirectToAction("Index", "ShowTimes");
        }

        // GET: ShowTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTimes = db.ShowTimes.Find(id);
            if (showTimes == null)
            {
                return HttpNotFound();
            }
            return View(showTimes);
        }

        // POST: ShowTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Room")] ShowTime showTimes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showTimes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showTimes);
        }

        // GET: ShowTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTimes = db.ShowTimes.Find(id);
            if (showTimes == null)
            {
                return HttpNotFound();
            }
            return View(showTimes);
        }

        // POST: ShowTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShowTime showTimes = db.ShowTimes.Find(id);
            db.ShowTimes.Remove(showTimes);
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
