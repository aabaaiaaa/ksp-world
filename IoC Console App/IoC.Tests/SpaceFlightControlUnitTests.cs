using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoC_Console_App;
using Autofac.Extras.Moq;
using Autofac;
using Moq;

namespace IoC.Tests
{
    [TestClass]
    public class SpaceFlightControlUnitTests
    {
        [TestMethod]
        public void Can_RegisterKerbals()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var expectedRocket = new Rocket();
                mock.Mock<IRocket>().Setup(m => m.AddPilot(It.IsAny<IKerbal>()));

                ISpaceFlightControl control = mock.Create<SpaceFlightControl>();
                control.RegisterPilot("Bill");

                mock.Mock<IRocket>().Verify(m => m.AddPilot(It.IsAny<IKerbal>()), Times.Once);
            }
        }
    }
}
