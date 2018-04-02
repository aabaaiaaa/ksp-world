using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    public class TimeEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public TimeEventArgs(int Hour, int Minute, int Second)
        {
            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;
        }
    }
}
