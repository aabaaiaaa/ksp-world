using System;
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

        [TestMethod]
        public void list_kerbals()
        {
            // Actual test
            var kerbals = _service.Get();

            Assert.AreEqual(0, kerbals.Count());
        }
    }
}
