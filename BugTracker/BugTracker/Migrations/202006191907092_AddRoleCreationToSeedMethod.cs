namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleCreationToSeedMethod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketPriority_Id", c => c.Int());
            AddColumn("dbo.Tickets", "TicketStatus_Id", c => c.Int());
            AddColumn("dbo.Tickets", "TicketType_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "TicketPriority_Id");
            CreateIndex("dbo.Tickets", "TicketStatus_Id");
            CreateIndex("dbo.Tickets", "TicketType_Id");
            AddForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities", "Id");
            AddForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus", "Id");
            AddForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities");
            DropIndex("dbo.Tickets", new[] { "TicketType_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id" });
            DropColumn("dbo.Tickets", "TicketType_Id");
            DropColumn("dbo.Tickets", "TicketStatus_Id");
            DropColumn("dbo.Tickets", "TicketPriority_Id");
        }
    }
}
