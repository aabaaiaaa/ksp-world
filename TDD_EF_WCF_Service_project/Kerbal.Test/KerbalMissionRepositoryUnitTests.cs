using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Collections.Generic;
using Kerbal.Data;

namespace Kerbal.Test
{
    [TestClass]
    public class KerbalMissionRepositoryUnitTests
    {
        [TestInitialize]
        public void Setup()
        {
            _mockDbContext = new Mock<KerbalDbContext>();
            _service = new KerbalRepository(_mockDbContext.Object);
        }

        private Mock<DbSet<Data.Kerbal>> _mockSet;
        private Mock<KerbalDbContext> _mockDbContext;
        private KerbalRepository _service;

        private Mock<DbSet<Data.Kerbal>> SetupQueryableMockedObject(IQueryable<Data.Kerbal> data, Mock<KerbalDbContext> mockDbContext)
        {
            var mockSet = new Mock<DbSet<Data.Kerbal>>();
            mockSet.As<IQueryable<Data.Kerbal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Data.Kerbal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Data.Kerbal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Data.Kerbal>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            mockDbContext.Setup(m => m.Kerbals).Returns(mockSet.Object);
            return mockSet;
        }

        [TestMethod]
        public void list_zero_kerbal_missions()
        {
            var data = new List<Data.Kerbal>() { }.AsQueryable();
            _mockSet = SetupQueryableMockedObject(data, _mockDbContext);

            var missionsKerbalsHaveBeenOn = _service.GetMissions();

            Assert.AreEqual(0, missionsKerbalsHaveBeenOn.Count());
        }

        [TestMethod]
        public void list_several_kerbal_missions()
        {
            var data = new List<Data.Kerbal>() {
                new Data.Kerbal()
                {
                    Name ="Valentina",
                    LastCompletedMission = new Mission(){
                        Ref = "first-flight-1",
                        TargetPlanet = "Mun"
                    }
                },
                new Data.Kerbal()
                {
                    Name = "Bob",
                    LastCompletedMission = new Mission()
                    {
                        Ref = "first-flight-2",
                        TargetPlanet = "Kerbin"
                    }
                }
            }.AsQueryable();
            _mockSet = SetupQueryableMockedObject(data, _mockDbContext);

            var missionsKerbalsHaveBeenOn = _service.GetMissions();

            Assert.AreEqual(2, missionsKerbalsHaveBeenOn.Count());
        }

        [TestMethod]
        public void list_kerbal_missions_by_target_planet()
        {
            var data = new List<Data.Kerbal>()
            {
                new Data.Kerbal()
                {
                    Name = "Bill",
                    LastCompletedMission = new Mission()
                    {
                        Ref = "mun-mission-6",
                        TargetPlanet = "Mun"
                    }
                },
                new Data.Kerbal()
                {
                    Name = "Bob",
                    LastCompletedMission = new Mission()
                    {
                        Ref = "mun-mission-9",
                        TargetPlanet = "Mun"
                    }
                }
            }.AsQueryable();
            _mockSet = SetupQueryableMockedObject(data, _mockDbContext);

            var missionsToTheMun = _service.GetMissions("Mun");

            Assert.AreEqual(2, missionsToTheMun.Count());
            Assert.AreEqual("Mun", missionsToTheMun.First().TargetPlanet);
            Assert.AreEqual("Mun", missionsToTheMun.ElementAt(1).TargetPlanet);
        }

        [TestMethod]
        public void get_kerbal_mission_by_ref()
        {
            var data = new List<Data.Kerbal>() {
                new Data.Kerbal()
                {
                    Name ="Valentina",
                    LastCompletedMission = new Mission(){
                        Ref = "first-flight-1",
                        TargetPlanet = "Mun"
                    }
                },
                new Data.Kerbal()
                {
                    Name = "Bob",
                    LastCompletedMission = new Mission()
                    {
                        Ref = "bob-flight-2",
                        TargetPlanet = "Kerbin"
                    }
                }
            }.AsQueryable();
            _mockSet = SetupQueryableMockedObject(data, _mockDbContext);

            var bobsMission = _service.GetMission("bob-flight-2");

            Assert.AreEqual("Kerbin", bobsMission.TargetPlanet);
            Assert.AreEqual("bob-flight-2", bobsMission.Ref);
        }

        [TestMethod]
        public void get_kerbal_mission_by_ref_that_does_not_exist()
        {
            var data = new List<Data.Kerbal>() { }.AsQueryable();
            _mockSet = SetupQueryableMockedObject(data, _mockDbContext);

            var nonExistentMissionRef = _service.GetMission("this-ref-does-not-exist");

            Assert.AreEqual(null, nonExistentMissionRef);
        }
    }
}
