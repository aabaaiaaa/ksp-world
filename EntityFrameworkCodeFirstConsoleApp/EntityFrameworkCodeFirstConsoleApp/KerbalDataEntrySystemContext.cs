using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstConsoleApp
{
    public class KerbalDataEntrySystemContext : DbContext
    {
        public DbSet<Kerbal> Kerbals { get; set; }
        public DbSet<FlightHistory> FlightHistory { get; set; }
        public DbSet<Crash> Crashes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crash>()
                .Property(c => c.CrashRef)
                .HasColumnName("CrashReference");
        }
    }
}
