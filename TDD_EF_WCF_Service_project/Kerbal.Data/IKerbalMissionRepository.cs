using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    public interface IKerbalMissionRepository
    {
        IEnumerable<Mission> GetMissions();
        IEnumerable<Mission> GetMissions(string targetPlanet);
        Mission GetMission(string missionRef);
    }
}
