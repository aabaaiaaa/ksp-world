using Kerbal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    public interface IKerbalRepository : IDataRepository<Kerbal>
    {
        Kerbal Get(string name);
        IEnumerable<Kerbal> Get(bool onMission);
    }
}
