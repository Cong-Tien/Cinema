using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Release { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}