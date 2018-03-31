﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kerbal.Test
{
    /// <summary>
    /// Will connect to local DB instance using a concrete EF implementation
    /// </summary>
    [TestClass]
    public class KerbalRepositoryIntegrationTests
    {
        #region Setup
        /// <summary>
        /// Sets up connection string details and EF DbContext for tests
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);
            _service = new Data.KerbalRepository(new Data.KerbalDbContext());
        }

        private static Data.KerbalRepository _service;

        /// <summary>
        /// Remove any existing kerbals
        /// </summary>
        [TestInitialize]
        public void RemoveExistingKerbals()
        {
            var existingKerbals = _service.Get().ToList();
            foreach (var k in existingKerbals)
                _service.Remove(k);
        }
        #endregion

        #region Integration Tests
        [TestMethod]
        public void list_kerbals()
        {
            // Actual test
            var kerbals = _service.Get();

            Assert.AreEqual(0, kerbals.Count());
        }

        [TestMethod]
        public void add_a_kerbal()
        {
            var kerbal = new Data.Kerbal() { Name = "Jebadiah" };
            _service.Add(kerbal);

            var newlyAddedKerbal = _service.Get("Jebadiah");

            Assert.AreEqual(kerbal, newlyAddedKerbal);
        }

        [TestMethod]
        public void list_kerbals_on_missions()
        {
            var kerbalOnMission = new Data.Kerbal() { Name = "Gene", OnMission = true };
            var kerbalNotOnMission = new Data.Kerbal() { Name = "Valentina" };
            _service.Add(kerbalOnMission);
            _service.Add(kerbalNotOnMission);
            var kerbalsOnMissions =_service.Get(true);

            Assert.AreEqual(1, kerbalsOnMissions.Count());
            Assert.AreEqual("Gene", kerbalsOnMissions.First().Name);
        }
        #endregion
    }
}
