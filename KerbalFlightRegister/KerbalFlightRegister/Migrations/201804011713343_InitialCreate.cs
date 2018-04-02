namespace KerbalFlightRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightCrews",
                c => new
                    {
                        FlightCrewId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        JoinedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightCrewId);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        MissionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TargetPlanet = c.String(),
                        FlightCrewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MissionId)
                .ForeignKey("dbo.FlightCrews", t => t.FlightCrewId, cascadeDelete: true)
                .Index(t => t.FlightCrewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Missions", "FlightCrewId", "dbo.FlightCrews");
            DropIndex("dbo.Missions", new[] { "FlightCrewId" });
            DropTable("dbo.Missions");
            DropTable("dbo.FlightCrews");
        }
    }
}
