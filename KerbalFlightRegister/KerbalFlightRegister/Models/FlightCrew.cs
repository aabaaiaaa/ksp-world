using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KerbalFlightRegister.Models
{
    public class FlightCrew
    {
        public int FlightCrewId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime JoinedDate { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}