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
            var personOne = new FastCarPerson() { Name = "Gene" };
            Console.WriteLine($"IsAnExtensionMethod: {personOne.IsAnExtensionMethod()}");

            List<ICar<FastCarPerson>> cars = new List<ICar<FastCarPerson>>();
            cars.Add(new FastCar<FastCarPerson>());
            Console.WriteLine(string.Format("Number of Gears: {0}", cars.First().NumberOfGears));
            Console.ReadKey();
            cars.First().StartEngine();
            FastCar<FastCarPerson> fastCar = (FastCar<FastCarPerson>)cars.First();
            fastCar.ChangeWheel();
            cars.First()[1] = new FastCarPerson() { Name = "Gene" };
            Console.ReadKey();
            Console.WriteLine($"Passenger 1: {cars.First()[1].Name}");
            Console.ReadKey();

            foreach (var prop in fastCar.GetType().GetProperties())
            {
                Console.WriteLine($"Property: {prop.Name}");
            }

            Console.ReadKey();
        }
    }
}
