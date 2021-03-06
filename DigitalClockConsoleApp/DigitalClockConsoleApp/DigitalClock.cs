﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class DigitalClock : IClockSubscriber
    {
        private void Clock_SecondHandChangedHandler(IClock clock, TimeEventArgs timeInfo)
        {
            Console.WriteLine(string.Format("Time is: {0} hours, {1} minutes, {2} seconds", timeInfo.Hour, timeInfo.Minute, timeInfo.Second));
        }

        public void Subscribe(IClock clock)
        {
            clock.SecondHandChangedHandler += Clock_SecondHandChangedHandler;
        }
    }
}
