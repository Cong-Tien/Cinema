using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class WatchingUpcommingViewModel
    {
   
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public IEnumerable<Watching> UpcommingMovies { get; set; }

    }
}