using AloneBirds.Models;
using AloneBirds.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AloneBirds.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext db;
        public TicketController()
        {
            db = new ApplicationDbContext();
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
                ticket.Price = 2000;
                ticket.State = 0;
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
            return RedirectToAction("Index_Movie", "Movies");
        }
        public ActionResult Index_Ticket(int id)
        {
            var tickets = db.Tickets
                .Where(a => a.WatchingId == id).ToList();
            return View(tickets);
            //return View(db.Tickets.ToList());
        }
        [HttpPost]
        public ActionResult Buy(int id)
        {
            var userId = User.Identity.GetUserId();
            var tickets = db.Tickets
                .FirstOrDefault(a => a.Id == id);

            tickets.State = 1; 
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