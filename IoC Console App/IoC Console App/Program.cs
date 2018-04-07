using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Console_App
{
    class Program
    {
        static IContainer Container;

        static void Main(string[] args)
        {
            // App startup
            var builder = new ContainerBuilder();
            builder.RegisterType<Kerbal>().As<IKerbal>();
            builder.RegisterType<Rocket>().As<IRocket>();
            builder.RegisterType<SpaceFlightControl>().As<ISpaceFlightControl>();
            Container = builder.Build();

            // App running
            using (var scope = Container.BeginLifetimeScope())
            {
                ISpaceFlightControl control = scope.Resolve<ISpaceFlightControl>();
                IRocket rocket = control.RegisterPilot("Bill");
                foreach (var prop in rocket.GetType().GetProperties())
                {
                    Console.WriteLine($"Prop: {prop.Name}, Value: {prop.GetValue(rocket)}");
                }
                Console.WriteLine($"Number of Pilots: {rocket.Pilots.Length}");
            }

            Console.ReadKey();
        }
    }
}
