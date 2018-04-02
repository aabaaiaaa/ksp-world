using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KerbalFlightRegister.Models
{
    public class FlightCrewMostMissions
    {
        public string Name { get; set; }
        public int NumberOfMissions { get; set; }
        public int MoreThanNextHighest { get; set; }
        public string SecondPosition { get; set; }
    }
}