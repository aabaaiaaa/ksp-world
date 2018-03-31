using Kerbal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostKerbalManager = new ServiceHost(typeof(KerbalManager));
            hostKerbalManager.Open();

            Console.WriteLine("Service started. To stop service, press any key...");
            Console.ReadKey();

            hostKerbalManager.Close();
        }
    }
}
