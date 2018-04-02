using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockConsoleApp
{
    class AsyncWork
    {
        public async void DoSlowWork()
        {
            Console.Write("Slow work begin");
            await SlowWork();
            Console.Write("Slow work END");
        }

        async Task SlowWork()
        {
            await Task.Delay(1000);
            for (var i = 0; i < 1000; i++)
            {
                Console.Write(".");
            }
        }
    }
}
