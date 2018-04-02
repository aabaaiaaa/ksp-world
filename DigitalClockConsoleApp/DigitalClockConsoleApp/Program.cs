using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IClock sharedClock = new Clock();
            sharedClock.StartClock();

            IClockSubscriber digitalClock = new DigitalClock();
            IClockSubscriber logClock = new Log();

            foreach(IClockSubscriber clockSub in new IClockSubscriber[2] { digitalClock, logClock })
            {
                clockSub.Subscribe(sharedClock);
            }

            AsyncWork asyncWork = new AsyncWork();
            asyncWork.DoSlowWork();

            Console.WriteLine(Environment.NewLine + "main thread start" + Environment.NewLine);
            for (var i = 0; i < 100; i++) Console.Write("X");
            Console.WriteLine(Environment.NewLine + "main thread END" + Environment.NewLine);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
