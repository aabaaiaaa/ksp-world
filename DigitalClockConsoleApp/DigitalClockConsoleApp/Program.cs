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
            var digitalClock = new DigitalClock();
            digitalClock.StartDigitalClock();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
