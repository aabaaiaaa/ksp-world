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
            LastMission = string.Format("Mission Ref: {0}, Target: {1}", k.LastCompletedMission?.Ref ?? "none", k.LastCompletedMission?.TargetPlanet ?? "none")
        };

        public IEnumerable<KerbalData> GetKerbalInfo(bool onMission)
        {
            var kerbalRepository = _kerbalRepository ?? new KerbalRepository(new KerbalDbContext());
            return kerbalRepository.Get(onMission).Select(toKerbalData);
        }

        public KerbalData GetKerbalInfo(int kerbalId)
        {
            var kerbalRepository = _kerbalRepository ?? new KerbalRepository(new KerbalDbContext());
            var kerbals = kerbalRepository.Get();
            return (from k in kerbals where k.KerbalId == kerbalId select k).Select(toKerbalData).First();
        }

        public KerbalData AddKerbalInfo(string name, string missionRef, string targetPlanet)
        {
            var kerbalRepository = _kerbalRepository ?? new KerbalRepository(new KerbalDbContext());
            var kerbalToAdd = new Data.Kerbal()
            {
                Name = name,
                LastCompletedMission = new Mission()
                {
                    Ref = missionRef,
                    TargetPlanet = targetPlanet
                }
            };
            return toKerbalData(kerbalRepository.Add(kerbalToAdd));
        }

        public void RemoveKerbalInfo(string name)
        {
            var kerbalRepository = _kerbalRepository ?? new KerbalRepository(new KerbalDbContext());
            var kerbalToRemove = kerbalRepository.Get(name);
            // Hack to load in Mission property
            var mission = kerbalToRemove.LastCompletedMission;
            kerbalRepository.Remove(kerbalToRemove);
        }
    }
}
