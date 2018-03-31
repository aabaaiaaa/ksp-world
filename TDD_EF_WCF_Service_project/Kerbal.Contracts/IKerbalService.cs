using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Contracts
{
    [ServiceContract]
    public interface IKerbalService
    {
        [OperationContract(Name = "GetKerbalInfoOfKerbalsOnMissions")]
        IEnumerable<KerbalData> GetKerbalInfo(bool onMission);

        [OperationContract(Name = "GetKerbalInfoById")]
        KerbalData GetKerbalInfo(int kerbalId);

        [OperationContract]
        KerbalData AddKerbalInfo(string name, string missionRef, string targetPlanet);

        [OperationContract]
        void RemoveKerbalInfo(string name);
    }
}
