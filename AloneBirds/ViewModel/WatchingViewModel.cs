using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class WatchingViewModel
    {
        public byte Movie { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public byte ShowTime { get; set; }
        public IEnumerable<ShowTime> ShowTimes { get; set; }

    }
}