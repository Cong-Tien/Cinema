using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class MovieViewModel
    {
        public IEnumerable<Movie> GetMovie { get; set; }
        public string NameMovie { get; set; }
    }
}