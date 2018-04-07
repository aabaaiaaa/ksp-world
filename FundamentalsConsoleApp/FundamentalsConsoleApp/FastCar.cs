using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsConsoleApp
{
    public struct FastCarPerson
    {
        public string Name { get; set; }
    }

    public class FastCar<T> : BaseCar<T> where T : struct
    {
        public FastCar(int numberOfGears = 6) : base(numberOfGears)
        {
            OnEngineStart += FastCar_OnEngineStart;
        }

        private void FastCar_OnEngineStart(ICar<T> car, bool engineStarted)
        {
            if (engineStarted) Console.WriteLine($"Time to burn rubber!");
        }
    }
}
