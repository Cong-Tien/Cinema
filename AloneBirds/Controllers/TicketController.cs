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
        //var watching = new Ticket
        //{

        //db.Watchings.Add(watching);
        //db.SaveChanges();
        //return RedirectToAction("Index", "Watchings");
        
    }
}