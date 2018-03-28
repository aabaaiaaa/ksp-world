using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstConsoleApp
{
    public class Kerbal
    {
        // Id property required by EF to uniquely identify data
        public int KerbalId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        // Virtual enables lazy loading of data for this property in EF
        public virtual List<FlightHistory> FlightHistory { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other,
        None
    }
}
