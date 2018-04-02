using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KerbalFlightRegister.Models
{
    public class FlightDb : DbContext
    {
        public FlightDb() : base("name=flightDb")
        {
                
        }

        public DbSet<FlightCrew> FlightCrew { get; set; }
        public DbSet<Mission> Missions { get; set; }
    }
}