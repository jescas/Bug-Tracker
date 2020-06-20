namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes");
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketType_Id" });
            RenameColumn(table: "dbo.Tickets", name: "TicketPriority_Id", newName: "TicketPriorityId");
            RenameColumn(table: "dbo.Tickets", name: "TicketStatus_Id", newName: "TicketStatusId");
            RenameColumn(table: "dbo.Tickets", name: "TicketType_Id", newName: "TicketTypeId");
            AlterColumn("dbo.Tickets", "TicketPriorityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "TicketStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "TicketTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TicketTypeId");
            CreateIndex("dbo.Tickets", "TicketPriorityId");
            CreateIndex("dbo.Tickets", "TicketStatusId");
            AddForeignKey("dbo.Tickets", "TicketPriorityId", "dbo.TicketPriorities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketPriorityId", "dbo.TicketPriorities");
            DropIndex("dbo.Tickets", new[] { "TicketStatusId" });
            DropIndex("dbo.Tickets", new[] { "TicketPriorityId" });
            DropIndex("dbo.Tickets", new[] { "TicketTypeId" });
            AlterColumn("dbo.Tickets", "TicketTypeId", c => c.Int());
            AlterColumn("dbo.Tickets", "TicketStatusId", c => c.Int());
            AlterColumn("dbo.Tickets", "TicketPriorityId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "TicketTypeId", newName: "TicketType_Id");
            RenameColumn(table: "dbo.Tickets", name: "TicketStatusId", newName: "TicketStatus_Id");
            RenameColumn(table: "dbo.Tickets", name: "TicketPriorityId", newName: "TicketPriority_Id");
            CreateIndex("dbo.Tickets", "TicketType_Id");
            CreateIndex("dbo.Tickets", "TicketStatus_Id");
            CreateIndex("dbo.Tickets", "TicketPriority_Id");
            AddForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes", "Id");
            AddForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus", "Id");
            AddForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities", "Id");
        }
    }
}
