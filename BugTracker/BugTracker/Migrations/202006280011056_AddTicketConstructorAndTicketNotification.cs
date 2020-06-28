namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketConstructorAndTicketNotification : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TicketNotifications", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.TicketNotifications", "ApplicationUserId");
            RenameColumn(table: "dbo.TicketNotifications", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AddColumn("dbo.TicketNotifications", "Title", c => c.String());
            AlterColumn("dbo.TicketNotifications", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TicketNotifications", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TicketNotifications", new[] { "ApplicationUserId" });
            AlterColumn("dbo.TicketNotifications", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.TicketNotifications", "Title");
            RenameColumn(table: "dbo.TicketNotifications", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.TicketNotifications", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.TicketNotifications", "ApplicationUser_Id");
        }
    }
}
