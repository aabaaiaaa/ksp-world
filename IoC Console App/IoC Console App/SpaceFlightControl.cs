using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Console_App
{
    public class SpaceFlightControl : ISpaceFlightControl
    {
        IRocket _availableRocket;

        public SpaceFlightControl(IRocket rocket)
        {
            _availableRocket = rocket;
        }

        public IRocket RegisterPilot(string name)
        {
            IKerbal newPilot = new Kerbal() { Name = name };
            _availableRocket.AddPilot(newPilot);
            return _availableRocket;
        }
    }
}
