using Kerbal.Contracts;
using Kerbal.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Test
{
    [TestClass]
    public class KerbalServiceIntegrationTests
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
            // Hack to "load" in the Mission entity so the subsequent "remove" call below actually removes Mission data too
            foreach (var k in existingKerbals) { var x = k.LastCompletedMission; }

            foreach (var k in existingKerbals)
                _service.Remove(k);
        }
        #endregion

        [TestMethod]
        public void can_start_up_servicehost_call_get_kerbal_info_then_add_then_get()
        {
            var serviceAddress = "net.pipe://localhost/IntegrationTestKerbalService";
            var binding = new NetNamedPipeBinding();
            var serviceHost = new ServiceHost(typeof(KerbalManager));
            var serviceEndPoint = serviceHost.AddServiceEndpoint(typeof(IKerbalService), binding, serviceAddress);
            serviceHost.Open();

            var channelFactory = new ChannelFactory<IKerbalService>(binding, new EndpointAddress(serviceAddress));
            var proxy = channelFactory.CreateChannel();
            var kerbalsNotOnMissions = proxy.GetKerbalInfo(false);
            
            Assert.AreEqual(0, kerbalsNotOnMissions.Count());

            proxy.AddKerbalInfo("Gene", "integration-flight-1", "Mun");

            kerbalsNotOnMissions = proxy.GetKerbalInfo(false);

            Assert.AreEqual(1, kerbalsNotOnMissions.Count());
            Assert.AreEqual("Gene", kerbalsNotOnMissions.First().Name);

            channelFactory.Close();
        }
    }
}
