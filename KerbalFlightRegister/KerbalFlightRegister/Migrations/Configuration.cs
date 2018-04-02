namespace KerbalFlightRegister.Migrations
{
    using KerbalFlightRegister.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KerbalFlightRegister.Models.FlightDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KerbalFlightRegister.Models.FlightDb";
        }

        protected override void Seed(FlightDb context)
        {
            context.FlightCrew.AddOrUpdate(fc => fc.FlightCrewId, new FlightCrew[]
            {
                new FlightCrew()
                {
                    FlightCrewId = 1,
                    Name = "Jebadiah",
                    Age = 35,
                    JoinedDate = new DateTime(2009, 1, 2),
                    Missions = new List<Mission>()
                    {
                        new Mission()
                        {
                            FlightCrewId = 1,
                            MissionId = 1,
                            Description = "First test flight",
                            TargetPlanet = "Kerbin"
                        },
                        new Mission()
                        {
                            FlightCrewId = 1,
                            MissionId = 2,
                            Description = "Second test flight",
                            TargetPlanet = "Kerbin"
                        }
                    }
                },
                new FlightCrew()
                {
                    FlightCrewId = 2,
                    Name = "Bill",
                    Age = 30,
                    JoinedDate = new DateTime(2010, 12, 22),
                    Missions = new List<Mission>()
                    {
                        new Mission()
                        {
                            FlightCrewId = 2,
                            MissionId = 3,
                            Description = "First test flight",
                            TargetPlanet = "Kerbin"
                        },
                        new Mission()
                        {
                            FlightCrewId = 2,
                            MissionId = 4,
                            Description = "Near orbit flight",
                            TargetPlanet = "Kerbin"
                        }
                    }
                },
                new FlightCrew()
                {
                    FlightCrewId = 3,
                    Name = "Bob",
                    Age = 28,
                    JoinedDate = new DateTime(2014, 7, 8)
                },
                new FlightCrew()
                {
                    FlightCrewId = 4,
                    Name = "Valentina",
                    Age = 25,
                    JoinedDate = new DateTime(2016, 6, 18)
                }
            });
        }
    }
}
