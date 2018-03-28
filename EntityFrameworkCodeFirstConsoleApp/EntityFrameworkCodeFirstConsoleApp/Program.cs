using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("----Please choose from this menu----");
                Console.WriteLine("1. Kerbal flight history input");
                Console.WriteLine("2. Rocket crash report");
                Console.WriteLine("3. Reports");
                Console.WriteLine("4. Exit system");
                Console.Write("Input menu number:");
                var menuChosen = Console.ReadKey();

                switch (menuChosen.KeyChar)
                {
                    case '1':
                        {
                            KerbalFlightEntry();
                            break;
                        }
                    case '2':
                        {
                            RocketCrashEntry();
                            break;
                        }
                    case '3':
                        {
                            ReportData();
                            break;
                        }
                    case '4':
                        {
                            exit = true;
                            break;
                        }
                }
                Console.Clear();
            }
        }

        static void KerbalFlightEntry()
        {
            Console.Clear();

            using (var db = new KerbalDataEntrySystemContext())
            {
                Console.Write("Please input Kerbal name:");
                var name = Console.ReadLine();

                Console.Write("Input name of Rocket:");
                var rocket = Console.ReadLine();

                var kerbal = new Kerbal()
                {
                    Name = name,
                    FlightHistory = new List<FlightHistory>()
                    {
                        new FlightHistory()
                        {
                            DateTime = DateTime.Now,
                            Rocket = new Rocket()
                            {
                                Name = rocket,
                                Height = 5.5,
                                Weight = 0.2
                            }
                        }
                    }
                };

                db.Kerbals.Add(kerbal);
                db.SaveChanges();

                foreach (var kernalEntry in (from k in db.Kerbals orderby k.Name select k))
                {
                    Console.WriteLine(string.Format("Kernalnaut name: {0}", kernalEntry.Name));
                }

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void RocketCrashEntry()
        {
            Console.Clear();

            using (var db = new KerbalDataEntrySystemContext())
            {
                Console.Write("Input rocket name:");
                var rocketName = Console.ReadLine();

                Console.Write("Input crash location:");
                var crashLocation = Console.ReadLine();

                var crashedRocket = new Crash()
                {
                    CrashRef = rocketName + "_" + crashLocation + "_" + new Random().Next(10000, 10000000),
                    Location = crashLocation,
                    Rocket = new Rocket()
                    {
                        Name = rocketName,
                        Height = 10,
                        Weight = 100
                    }
                };

                db.Crashes.Add(crashedRocket);
                db.SaveChanges();

                foreach (var entry in (from k in db.Crashes orderby k.Location select k))
                {
                    Console.WriteLine(string.Format("Rocket Crashed: {0}", entry.Rocket.Name));
                    Console.WriteLine(string.Format("Location Crashed: {0}", entry.Location));
                }

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ReportData()
        {
            Console.Clear();

            using (var db = new KerbalDataEntrySystemContext())
            {
                Console.WriteLine("----List of Kerbals:----");
                foreach (var entry in (from k in db.Kerbals select k))
                {
                    Console.WriteLine(string.Format("Kerbal name: {0}", entry.Name));
                }

                Console.WriteLine("");
                Console.WriteLine("----List of Crashes:----");
                foreach (var entry in (from k in db.Crashes select k))
                {
                    Console.WriteLine(string.Format("Crash reference: {0}", entry.CrashRef));
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
