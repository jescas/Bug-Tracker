namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "isUpdated", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tickets", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Updated", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tickets", "isUpdated");
        }
    }
}
