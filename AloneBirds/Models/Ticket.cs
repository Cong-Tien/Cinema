using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AloneBirds.Models
{
    public class Ticket
    {

        public int Id { get; set; }
        public ApplicationUser Clients { get; set; }
        public string ClientsID { get; set; }

        public string Seat { get; set; }
        public double Price { get; set; }
        public int State { get; set; }
        
        public Watching Watching { get; set; }
        [Required]
        public byte WatchingId { get; set; }
  


    }
}