namespace RosondFleetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicles", "VIN", c => c.String(nullable: false, maxLength: 17));
            CreateIndex("dbo.Vehicles", "VIN", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "VIN" });
            AlterColumn("dbo.Vehicles", "VIN", c => c.String());
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Make", c => c.String());
        }
    }
}
