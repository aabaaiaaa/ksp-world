using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    public class KerbalDbContext : DbContext
    {
        public virtual DbSet<Kerbal> Kerbals { get; set; }
    }
}
