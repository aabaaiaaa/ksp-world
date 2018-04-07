using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICar<FastCarPerson>> cars = new List<ICar<FastCarPerson>>();
            cars.Add(new FastCar<FastCarPerson>());
            Console.WriteLine(string.Format("Number of Gears: {0}", cars.First().NumberOfGears));
            Console.ReadKey();
            cars.First().StartEngine();
            cars.First()[1] = new FastCarPerson() { Name = "Gene" };
            Console.ReadKey();
            Console.WriteLine($"Passenger 1: {cars.First()[1].Name}");
            Console.ReadKey();
        }
    }
}
