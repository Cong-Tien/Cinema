using AloneBirds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloneBirds.ViewModel
{
    public class TicketViewModel
    {
       public byte Watching { get; set; }
        public IEnumerable<Watching> Watchings { get; set; }
    }
}