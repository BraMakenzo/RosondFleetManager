namespace RosondFleetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncModels : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vehicles", new[] { "VIN" });
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Vehicles", "VIN", unique: true);
        }
    }
}
