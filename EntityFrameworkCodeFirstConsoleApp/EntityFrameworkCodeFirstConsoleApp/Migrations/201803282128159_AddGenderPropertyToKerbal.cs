namespace EntityFrameworkCodeFirstConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderPropertyToKerbal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kerbals", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kerbals", "Gender");
        }
    }
}
