using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class Clock
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Clock()
        {
            var now = DateTime.Now;
            Hour = now.Hour;
            Minute = now.Minute;
            Second = now.Second;
        }

        public delegate void SecondHandChangedDelegate(Clock clock, TimeEventArgs timeInfo);

        public event SecondHandChangedDelegate SecondHandChangedHandler;

        public void StartClock()
        {
            void clockTick()
            {
                for (; ; )
                {
                    Thread.Sleep(100);
                    var now = DateTime.Now;
                    if (now.Second != Second)
                    {
                        Second = now.Second;
                        SecondHandChangedHandler?.Invoke(this, new TimeEventArgs(now.Hour, now.Minute, now.Second));
                    }
                }
            }
            Thread thread = new Thread(clockTick);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
