using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    /// <summary>
    /// Will use the connection string "kerbalDbContext" from config
    /// </summary>
    public class KerbalDbContext : DbContext
    {
        public KerbalDbContext() : base("kerbalDbContext") { }

        public virtual DbSet<Kerbal> Kerbals { get; set; }
    }
}
