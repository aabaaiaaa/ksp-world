using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KerbalFlightRegister.Models
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string Description { get; set; }
        public string TargetPlanet { get; set; }
        public int FlightCrewId { get; set; }
    }
}