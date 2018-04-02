using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    delegate void SecondHandChangedDelegate(IClock clock, TimeEventArgs timeInfo);

    interface IClock
    {
        event SecondHandChangedDelegate SecondHandChangedHandler;
        void StartClock();
    }
}
