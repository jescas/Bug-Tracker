namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketPriorities", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketStatus", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketTypes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TicketPriorities", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TicketStatus", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TicketTypes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.TicketPriorities", "ApplicationUser_Id");
            DropColumn("dbo.TicketStatus", "ApplicationUser_Id");
            DropColumn("dbo.TicketTypes", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketTypes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TicketStatus", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TicketPriorities", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TicketTypes", "ApplicationUser_Id");
            CreateIndex("dbo.TicketStatus", "ApplicationUser_Id");
            CreateIndex("dbo.TicketPriorities", "ApplicationUser_Id");
            AddForeignKey("dbo.TicketTypes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TicketStatus", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TicketPriorities", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
