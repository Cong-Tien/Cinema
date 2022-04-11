using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class WatchingUpcommingViewModel_Room
    {
        public DateTime DateTime { get; set; }
        public string RoomName { get; set; }
        public double Fare { get; set; }
        public IEnumerable<Watching> UpcommingMovies_Room { get; set; }

    }
}