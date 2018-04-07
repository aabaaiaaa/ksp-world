using System;
using FundamentalsConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FastCarTests
    {
        [TestInitialize]
        public void setup()
        {
            onEngineStartEventHandlerFired = false;
        }

        [TestMethod]
        public void EngineStartupEventFires()
        {
            var car = new FastCar<FastCarPerson>();
            car.OnEngineStart += Car_OnEngineStart;
            car.StartEngine();

            Assert.AreEqual(true, onEngineStartEventHandlerFired);
        }

        [TestMethod]
        public void AddAPassenger()
        {
            var car = new FastCar<FastCarPerson>();
            car[0] = new FastCarPerson() { Name = "Bill" };

            Assert.AreEqual("Bill", car[0].Name);
        }

        private bool onEngineStartEventHandlerFired;

        private void Car_OnEngineStart(ICar<FastCarPerson> car, bool engineStarted)
        {
            onEngineStartEventHandlerFired = true;
        }
    }
}
