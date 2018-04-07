using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Console_App
{
    public class Rocket : IRocket
    {
        public IKerbal[] Pilots => _pilotsList.ToArray();

        private List<IKerbal> _pilotsList = new List<IKerbal>();

        public IKerbal[] AddPilot(IKerbal pilot)
        {
            _pilotsList.Add(pilot);
            return _pilotsList.ToArray();
        }
    }
}
