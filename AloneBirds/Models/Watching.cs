using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloneBirds.Models
{
    public class Watching
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public ShowTime ShowTime { get; set; }
      
        public int ShowTimeId { get; set; }

        public Movie Movie { get; set; }

        public int sold { get; set; }
    
       
        public int MovieId { get; set; }
        //public IEnumerable<Watching> UpcommingMovies { get; set; }
  
    }
}