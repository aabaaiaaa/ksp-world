namespace EntityFrameworkCodeFirstConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightHistories",
                c => new
                    {
                        FlightHistoryId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Rocket_RocketId = c.Int(),
                        Kerbal_KerbalId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightHistoryId)
                .ForeignKey("dbo.Rockets", t => t.Rocket_RocketId)
                .ForeignKey("dbo.Kerbals", t => t.Kerbal_KerbalId)
                .Index(t => t.Rocket_RocketId)
                .Index(t => t.Kerbal_KerbalId);
            
            CreateTable(
                "dbo.Rockets",
                c => new
                    {
                        RocketId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RocketId);
            
            CreateTable(
                "dbo.Kerbals",
                c => new
                    {
                        KerbalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.KerbalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightHistories", "Kerbal_KerbalId", "dbo.Kerbals");
            DropForeignKey("dbo.FlightHistories", "Rocket_RocketId", "dbo.Rockets");
            DropIndex("dbo.FlightHistories", new[] { "Kerbal_KerbalId" });
            DropIndex("dbo.FlightHistories", new[] { "Rocket_RocketId" });
            DropTable("dbo.Kerbals");
            DropTable("dbo.Rockets");
            DropTable("dbo.FlightHistories");
        }
    }
}
