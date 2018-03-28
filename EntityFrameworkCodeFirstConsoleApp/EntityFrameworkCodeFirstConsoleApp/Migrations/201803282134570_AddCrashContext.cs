namespace EntityFrameworkCodeFirstConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCrashContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crashes",
                c => new
                    {
                        CrashRef = c.String(nullable: false, maxLength: 128),
                        Location = c.String(),
                        Rocket_RocketId = c.Int(),
                    })
                .PrimaryKey(t => t.CrashRef)
                .ForeignKey("dbo.Rockets", t => t.Rocket_RocketId)
                .Index(t => t.Rocket_RocketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Crashes", "Rocket_RocketId", "dbo.Rockets");
            DropIndex("dbo.Crashes", new[] { "Rocket_RocketId" });
            DropTable("dbo.Crashes");
        }
    }
}
