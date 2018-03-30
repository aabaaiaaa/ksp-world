using System;
using System.Collections.Generic;
using System.Data.Entity;
using Kerbal.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace Kerbal.Test
{
    [TestClass]
    public class KerbalRepositoryUnitTests
    {
        public Mock<DbSet<Data.Kerbal>> _mockSet;
        public Mock<KerbalDbContext> _mockContext;
        public KerbalRepository _service;

        [TestInitialize]
        public void InitialiseMocks()
        {
            _mockSet = new Mock<DbSet<Data.Kerbal>>();
            _mockContext = new Mock<KerbalDbContext>();
            _service = new KerbalRepository(_mockContext.Object);
        }

        [TestMethod]
        public void add_kerbal()
        {
            _mockContext.Setup(m => m.Kerbals).Returns(_mockSet.Object);

            // Actual tests
            _service.Add(new Data.Kerbal() { Name = "Jebadiah" });

            _mockSet.Verify(m => m.Add(It.IsAny<Data.Kerbal>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void list_kerbals()
        {
            // Setup test data
            var data = new List<Data.Kerbal>()
            {
                new Data.Kerbal(){ Name = "Jebadiah" },
                new Data.Kerbal(){ Name = "Bill" }
            }.AsQueryable();

            // Connect data to mock
            var mockSetDataSetup = _mockSet.As<IQueryable<Data.Kerbal>>();
            mockSetDataSetup.Setup(m => m.Provider).Returns(data.Provider);
            mockSetDataSetup.Setup(m => m.Expression).Returns(data.Expression);
            mockSetDataSetup.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSetDataSetup.Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            _mockContext.Setup(m => m.Kerbals).Returns(_mockSet.Object);

            // Actual tests
            var kerbals = _service.Get();

            Assert.AreEqual(2, kerbals.Count());
            Assert.AreEqual("Bill", kerbals.ElementAt(1).Name);
        }

        [TestMethod]
        public void list_kerbals_on_missions()
        {
            var data = new List<Data.Kerbal>()
            {
                new Data.Kerbal(){ Name = "Bill", OnMission = false },
                new Data.Kerbal(){Name = "Gene", OnMission = true }
            }.AsQueryable();

            // Connect data to mock
            var mockSetup = _mockSet.As<IQueryable<Data.Kerbal>>();
            mockSetup.Setup(m => m.Provider).Returns(data.Provider);
            mockSetup.Setup(m => m.Expression).Returns(data.Expression);
            mockSetup.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSetup.Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            _mockContext.Setup(m => m.Kerbals).Returns(_mockSet.Object);

            // Actual test
            var kerbalsOnMission = _service.Get(true);

            Assert.AreEqual(1, kerbalsOnMission.Count());
            Assert.AreEqual("Gene", kerbalsOnMission.First().Name);
        }
    }
}
