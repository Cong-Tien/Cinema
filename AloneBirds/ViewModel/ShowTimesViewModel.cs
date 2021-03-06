using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class ShowTimesViewModel
    {

        public string Date { get; set; }
        public string Time { get; set; }
        public int Room { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public double Fare { get; set; }


        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}