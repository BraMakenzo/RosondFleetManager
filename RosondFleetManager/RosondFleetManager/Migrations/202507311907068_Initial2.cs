namespace RosondFleetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "VIN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VIN", c => c.String(nullable: false, maxLength: 17));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
