using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Room { get; set; }
        public int Fare { get; set; }

    }
}