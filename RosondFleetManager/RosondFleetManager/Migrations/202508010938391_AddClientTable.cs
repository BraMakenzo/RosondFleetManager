namespace RosondFleetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "ContactInfo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "ContactInfo", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
