using Kerbal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Proxy
{
    public class KerbalProxy : ClientBase<IKerbalService>, IKerbalService
    {
        public KerbalData AddKerbalInfo(string name, string missionRef, string targetPlanet)
        {
            return Channel.AddKerbalInfo(name, missionRef, targetPlanet);
        }

        public IEnumerable<KerbalData> GetKerbalInfo(bool onMission)
        {
            return Channel.GetKerbalInfo(onMission);
        }

        public KerbalData GetKerbalInfo(int kerbalId)
        {
            return Channel.GetKerbalInfo(kerbalId);
        }

        public void RemoveKerbalInfo(string name)
        {
            Channel.RemoveKerbalInfo(name);
        }
    }
}
