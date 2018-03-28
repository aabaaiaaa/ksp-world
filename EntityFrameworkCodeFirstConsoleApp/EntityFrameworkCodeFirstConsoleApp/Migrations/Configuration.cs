namespace EntityFrameworkCodeFirstConsoleApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkCodeFirstConsoleApp.KerbalDataEntrySystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityFrameworkCodeFirstConsoleApp.FlightHistoryContext";
        }

        protected override void Seed(EntityFrameworkCodeFirstConsoleApp.KerbalDataEntrySystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
