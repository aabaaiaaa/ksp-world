using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class Log : IClockSubscriber
    {
        private void Clock_SecondHandChangedHandler(IClock clock, TimeEventArgs timeInfo)
        {
            Console.WriteLine($"Log: {timeInfo.Hour}:{timeInfo.Minute}:{timeInfo.Second}");
        }

        public void Subscribe(IClock clock)
        {
            clock.SecondHandChangedHandler += Clock_SecondHandChangedHandler;
        }
    }
}
