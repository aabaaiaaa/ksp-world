using System;

namespace EntityFrameworkCodeFirstConsoleApp
{
    public class FlightHistory
    {
        // EF to set primary key
        public int FlightHistoryId { get; set; }
        public DateTime DateTime { get; set; }
        //TODO: add list of kerbals that were part of this flight
        public Rocket Rocket { get; set; }
    }
}