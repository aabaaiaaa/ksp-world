using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsConsoleApp
{
    public static class CarExtensions
    {
        public static bool IsAnExtensionMethod(this FastCarPerson person)
        {
            return true;
        }

        public static void ChangeWheel<T>(this FastCar<T> car) where T : struct
        {
            Console.WriteLine($"Changed the wheels for the car: {car.NumberOfGears}");
        }
    }
}
