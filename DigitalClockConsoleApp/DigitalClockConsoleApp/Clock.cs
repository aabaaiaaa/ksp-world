using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class Clock : IClock
    {
        private int Second { get; set; }

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
