using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kerbal.Contracts;
using Kerbal.Data;
using Kerbal.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kerbal.Test
{
    [TestClass]
    public class KerbalManagerUnitTests
    {
        [TestInitialize]
        public void Setup()
        {
            _kerbalData = new List<Data.Kerbal>()
            {
                new Data.Kerbal()
                {
                    KerbalId = 1001,
                    Name = "Jebadiah",
                    LastCompletedMission = new Mission()
                    {
                        Ref = "test-flight-001",
                        TargetPlanet = "Mun"
                    }
                },
                new Data.Kerbal()
                {
                    KerbalId = 1002,
                    Name = "Bill",
                    OnMission = true,
                    LastCompletedMission = new Mission()
                    {
                        Ref = "real-flight-101",
                        TargetPlanet = "Duna"
                    }
                }
            }.AsEnumerable();
            _mockKerbalRepository = new Mock<IKerbalRepository>();
            _mockKerbalRepository.Setup(m => m.Get()).Returns(_kerbalData);
            _mockKerbalRepository.Setup(m => m.Get(true)).Returns(_kerbalData.Where(k => k.OnMission));
            _kerbalManager = new KerbalManager(_mockKerbalRepository.Object);
        }
        private Mock<IKerbalRepository> _mockKerbalRepository;
        private IEnumerable<Data.Kerbal> _kerbalData;
        private IKerbalService _kerbalManager;

        [TestMethod]
        public void get_kerbal_info_by_kerbal_id_I()
        {
            var kerbalById = _kerbalManager.GetKerbalInfo(1001);

            Assert.AreEqual("Jebadiah", kerbalById.Name);
            Assert.AreEqual("Mission Ref: test-flight-001, Target: Mun", kerbalById.LastMission);
        }

        [TestMethod]
        public void get_kerbal_info_by_kerbal_id_II()
        {
            var kerbalById = _kerbalManager.GetKerbalInfo(1002);

            Assert.AreEqual("Bill", kerbalById.Name);
            Assert.AreEqual("Mission Ref: real-flight-101, Target: Duna", kerbalById.LastMission);
        }

        [TestMethod]
        public void get_kerbal_info_by_kerbals_on_missions()
        {
            var kerbalsOnMissions = _kerbalManager.GetKerbalInfo(true);

            Assert.AreEqual(1, kerbalsOnMissions.Count());
            Assert.AreEqual("Bill", kerbalsOnMissions.First().Name);
        }
    }
}
