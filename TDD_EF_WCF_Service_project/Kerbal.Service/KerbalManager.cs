using Kerbal.Contracts;
using Kerbal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Service
{
    public class KerbalManager : IKerbalService
    {
        // Allows for testing/mocking
        private IKerbalRepository _kerbalRepository;
        public KerbalManager(IKerbalRepository kerbalRepository)
        {
            _kerbalRepository = kerbalRepository;
        }
        public KerbalManager() { }

        private Func<Data.Kerbal, KerbalData> toKerbalData = k => new KerbalData() {
            Name = k.Name,
            LastMission = string.Format("Mission Ref: {0}, Target: {1}", k.LastCompletedMission.Ref, k.LastCompletedMission.TargetPlanet)
        };

        public IEnumerable<KerbalData> GetKerbalInfo(bool onMission)
        {
            var kerbalRepository = _kerbalRepository ?? new KerbalRepository(new KerbalDbContext());
            return kerbalRepository.Get(true).Select(toKerbalData);
        }

        public KerbalData GetKerbalInfo(int kerbalId)
        {
            var kerbalRepository = _kerbalRepository ?? new KerbalRepository(new KerbalDbContext());
            var kerbals = kerbalRepository.Get();
            return (from k in kerbals where k.KerbalId == kerbalId select k).Select(toKerbalData).First();
        }
    }
}
