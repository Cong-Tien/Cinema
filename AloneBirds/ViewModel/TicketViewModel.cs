using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string ClientsID { get; set; }

        public string Seat { get; set; }
        public double Price { get; set; }
        public int State { get; set; }
        public int Watching { get; set; }
       public IEnumerable<Watching> Watchings { get; set; }

    }
}