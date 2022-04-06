using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AloneBirds.Models
{
    public class Watching
    {
        public int Id { get; set; }


        public ShowTime ShowTime { get; set; }
        [Required]
        public byte ShowTimeId { get; set; }

        public Movie Movie { get; set; }
        [Required]
        public byte MovieId { get; set; }


       

        //public Category Category { get; set; }
        //public Byte CategoryId { get; set; }

    }
}