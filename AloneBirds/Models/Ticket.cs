using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Seat { get; set; }
        public double Price { get; set; }
        public DateTime ShowTimes { get; set; }
        public string State { get; set; }
        public string Room { get; set; }

        public ApplicationUser Client { get; set; }
        public string ClientID { get; set; }


        public virtual Movie Movie { get; set; }
    }
}