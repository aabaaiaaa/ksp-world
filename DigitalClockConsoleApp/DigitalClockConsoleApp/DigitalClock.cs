using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class DigitalClock
    {
        public DigitalClock()
        {
            Clock = new Clock();

            Clock.SecondHandChangedHandler += Clock_SecondHandChangedHandler;
        }

        private void Clock_SecondHandChangedHandler(Clock clock, TimeEventArgs timeInfo)
        {
            Console.WriteLine(string.Format("Time is: {0} hours, {1} minutes, {2} seconds", timeInfo.Hour, timeInfo.Minute, timeInfo.Second));
        }

        private Clock Clock { get; set; }

        public void StartDigitalClock()
        {
            Clock.StartClock();
        }
    }
}
