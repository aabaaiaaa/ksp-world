using System;
using IoC_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoC.Tests
{
    [TestClass]
    public class RocketTests
    {
        Mock<IKerbal> jebadiah;
        Mock<IKerbal> bill;
        [TestInitialize]
        public void Setup_Mocks_For_each_test()
        {
            jebadiah = new Mock<IKerbal>();
            jebadiah.Setup(m => m.Name).Returns("Jebadiah");

            bill = new Mock<IKerbal>();
            bill.Setup(m => m.Name).Returns("Bill");
        }

        [TestMethod]
        public void Can_AddPilots_ToRocket()
        {
            IKerbal[] expectedPilotList = new IKerbal[] { jebadiah.Object };

            Rocket rocket = new Rocket();
            IKerbal[] actualPilotList = rocket.AddPilot(jebadiah.Object);

            Assert.AreEqual(expectedPilotList[0], actualPilotList[0]);
        }

        [TestMethod]
        public void Can_AddPilots_MultiplePilots_ToRocket()
        {

            IKerbal[] expectedPilotList = new IKerbal[] { jebadiah.Object, bill.Object };

            Rocket rocket = new Rocket();
            rocket.AddPilot(jebadiah.Object);
            IKerbal[] actualPilotList = rocket.AddPilot(bill.Object);

            Assert.AreEqual(2, actualPilotList.Length);
            Assert.AreEqual(expectedPilotList[0].Name, actualPilotList[0].Name);
            Assert.AreEqual(expectedPilotList[1].Name, actualPilotList[1].Name);
        }

        [TestMethod]
        public void Can_ListPilots_AlreadyAdded()
        {
            IKerbal[] expectedPilotList = new IKerbal[] { jebadiah.Object, bill.Object };

            Rocket rocket = new Rocket();
            rocket.AddPilot(jebadiah.Object);
            rocket.AddPilot(bill.Object);

            Assert.AreEqual(2, rocket.Pilots.Length);
            Assert.AreEqual(expectedPilotList[0].Name, rocket.Pilots[0].Name);
            Assert.AreEqual(expectedPilotList[1].Name, rocket.Pilots[1].Name);
        }

        [TestMethod]
        public void Can_Add_ConcreteKerbals()
        {
            IKerbal realBill = new Kerbal() { Name = "Bill" };
            IRocket realRocket = new Rocket();

            IKerbal[] listOfPilots = realRocket.AddPilot(realBill);
            Assert.AreEqual(1, listOfPilots.Length);
            Assert.AreEqual("Bill", listOfPilots[0].Name);
        }

        [TestMethod]
        public void Can_List_ConcreteKerbals()
        {
            IKerbal realBill = new Kerbal() { Name = "Bill" };
            IRocket realRocket = new Rocket();

            realRocket.AddPilot(realBill);
            Assert.AreEqual(1, realRocket.Pilots.Length);
            Assert.AreEqual("Bill", realRocket.Pilots[0].Name);
        }
    }
}
