using AloneBirds.Models;
using AloneBirds.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace AloneBirds.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext db;
        public TicketController()
        {
            db = new ApplicationDbContext();
        }
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
                return View(db.Tickets.ToList());
            }
            if (user.CategoryClient == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Base");
        }
            // GET: Ticket
        public ActionResult Create()
        {
            var viewModel = new TicketViewModel
            {
                Watchings = db.Watchings.ToList(),
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult MyTicket()
        {
            var userId = User.Identity.GetUserId();
            var ticket = db.Tickets
                .Where(c => c.ClientsID == userId)
                .Include(l => l.Watching)
                .Include(l => l.Watching.ShowTime)
                .Include(l => l.Watching.Movie).ToList();

           
            return View(ticket);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel viewModel)
        {
            for (int i = 0; i < 128; i++)
            {
                //var ticket = new Ticket
                //{
                //    ClientsID = User.Identity.GetUserId(),
                //    Seat = i.ToString(),
                //    State = 0,
                //    Price=10000,
                //    WatchingId=viewModel.Watching                  
                //};
                //db.Tickets.Add(ticket);
                //db.SaveChanges();
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
                ticket.ClientsID = User.Identity.GetUserId();
                ticket.WatchingId = viewModel.Watching;
                ticket.Price = viewModel.Price;
                ticket.State = 0;
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
            return RedirectToAction("Index_Watching", "Watchings");
        }
        [Authorize]
        public ActionResult Index_Ticket(int id)
        {
            var tickets = db.Tickets
                .Include(a=>a.Watching)
                .Include(a=>a.Watching.ShowTime)
                .Include(a=>a.Watching.ShowTime.Room)
                .Include(a=>a.Watching.Movie)
                .Where(a => a.WatchingId == id);

            //var upcoming = db.Watchings
            //    .Include(c => c.Movie)
            //    .Include(c => c.ShowTime)
            //    .FirstOrDefault(c => c.WatchingId = id);
            //var viewModel = new WatchingUpcommingViewModel
            //{
            //    UpcommingMovies = upcoming
            //};
            return View("Index_Ticket", tickets/*, "_Layout_Ticket", viewModel*/);
        }

        [HttpPost]
        public ActionResult Buy(int id, TicketViewModel viewModel)
        {
           
            var userId = User.Identity.GetUserId();
            var tickets = db.Tickets
                .Include(a=>a.Watching.ShowTime)
                .FirstOrDefault(a => a.Id == id);

            tickets.State = 1;
            //tickets.Price = viewModel.Price;
            tickets.ClientsID = userId;
            //var ticket = new Ticket
            //{
            //    Id = id,
            //    ClientsID = userId /*tickets.ClientId*/,
            //    State = 1,
            //    Price = 1200,
            //    Seat = tickets.Seat
            //};
            db.SaveChanges();
            return RedirectToAction("Index_Ticket", "Ticket", new { id =tickets.WatchingId});
        }
        //public ActionResult Buy(int id)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var tickets = db.Tickets
        //        .FirstOrDefault(a => a.Id == id);
        //    //.Include(c => c.Watching);
        //    var viewModel = new TicketViewModel
        //    {
        //        Watchings = db.Watchings.ToList(),
        //        ClientsID = userId,
        //        State = tickets.State,
        //        Price = tickets.Price,
        //        Seat = tickets.Seat,
        //        Watching = tickets.WatchingId,
        //        Id = tickets.Id
        //    };


        //    return View("Index_Ticket", viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(TicketViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        viewModel.Watchings = db.Watchings.ToList();
        //        return View(viewModel);
        //    }
        //    var userId = User.Identity.GetUserId();
        //    var tickets = db.Tickets.FirstOrDefault(a => a.Id == viewModel.Id);
        //    tickets.State = 1;
        //    tickets.Price = viewModel.Price;
        //    tickets.Seat = viewModel.Seat;
        //    tickets.WatchingId = viewModel.Watching;
        //    db.SaveChanges();

        //    return RedirectToAction("Index_Watching", "Watchings");
        //}
    }
}