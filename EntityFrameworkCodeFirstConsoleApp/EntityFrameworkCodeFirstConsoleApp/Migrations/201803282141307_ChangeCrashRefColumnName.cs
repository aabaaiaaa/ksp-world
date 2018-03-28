namespace EntityFrameworkCodeFirstConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCrashRefColumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Crashes", name: "CrashRef", newName: "CrashReference");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Crashes", name: "CrashReference", newName: "CrashRef");
        }
    }
}
