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
    public class WatchingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Watchings
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
                var upcommingMovies = db.Watchings
                .Include(c => c.Movie)
                .Include(c => c.ShowTime).ToList();
                var viewModel = new WatchingUpcommingViewModel
                {
                    UpcommingMovies = upcommingMovies
                };
                return View(viewModel);
            }
            if (user.CategoryClient == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Base");
            
        }
        public ActionResult Index_Watching()
        {
            //var search = db.Watchings
            //    .Include(c => c.Movie)
            //   .Include(c => c.ShowTime)
            //   .Where(a => a.Movie.Release > DateTime.Now).ToList();
            //return View(search);
            var upcommingMovies = db.Watchings
                .Include(c => c.Movie)
                .Include(c => c.ShowTime).ToList();
            var viewModel = new WatchingUpcommingViewModel
            {
                UpcommingMovies = upcommingMovies
            };
            return View(viewModel);
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
                ShowTimeId = viewModel.ShowTime,
                sold = 0
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

        public ActionResult Create_Ticket(int id)
        {        
            for (int i = 0; i < 128; i++)
            {              
                var ticket = new Ticket();
                if (i < 15)
                    ticket.Seat = "A" + (i + 1).ToString();
                if (i > 14 && i < 30)
                    ticket.Seat = "B" + (i + 1 - 15).ToString();
                if (i > 29 && i < 45)
                    ticket.Seat = "C" + (i + 1 - 30).ToString();
                if (i > 44 && i < 60)
                    ticket.Seat = "D" + (i + 1 - 45).ToString();
                if (i > 59 && i < 75)
                    ticket.Seat = "E" + (i + 1 - 60).ToString();
                if (i > 74 && i < 90)
                    ticket.Seat = "F" + (i + 1 - 75).ToString();
                if (i > 89 && i < 105)
                    ticket.Seat = "G" + (i + 1 - 90).ToString();
                if (i > 104 && i < 120)
                    ticket.Seat = "H" + (i + 1 - 105).ToString();
                if (i > 119 && i < 135)
                    ticket.Seat = "I" + (i + 1 - 120).ToString();
                if (i > 134 && i < 143)
                    ticket.Seat = "H" + (i + 1 - 128).ToString();
                ticket.WatchingId = id;
                ticket.Price = 0;
                ticket.State = 0;
                db.Tickets.Add(ticket);
          

                var tickets = db.Watchings               
                    .FirstOrDefault(a => a.Id == id);

                tickets.sold = 1;               
                db.SaveChanges();

            }
            return RedirectToAction("Index_Watching", "Watchings");
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
