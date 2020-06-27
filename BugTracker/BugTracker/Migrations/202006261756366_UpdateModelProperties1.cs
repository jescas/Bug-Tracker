namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelProperties1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedTo_Id" });
            DropIndex("dbo.Tickets", new[] { "OwnerUser_Id" });
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Tickets", "AssignedToUserId");
            DropColumn("dbo.Tickets", "OwnerUserId");
            RenameColumn(table: "dbo.Tickets", name: "AssignedTo_Id", newName: "AssignedToUserId");
            RenameColumn(table: "dbo.Tickets", name: "OwnerUser_Id", newName: "OwnerUserId");
            AlterColumn("dbo.Tickets", "OwnerUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "AssignedToUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "OwnerUserId");
            CreateIndex("dbo.Tickets", "AssignedToUserId");
            DropColumn("dbo.Tickets", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropIndex("dbo.Tickets", new[] { "AssignedToUserId" });
            DropIndex("dbo.Tickets", new[] { "OwnerUserId" });
            AlterColumn("dbo.Tickets", "AssignedToUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "OwnerUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tickets", name: "OwnerUserId", newName: "OwnerUser_Id");
            RenameColumn(table: "dbo.Tickets", name: "AssignedToUserId", newName: "AssignedTo_Id");
            AddColumn("dbo.Tickets", "OwnerUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "AssignedToUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ApplicationUser_Id");
            CreateIndex("dbo.Tickets", "OwnerUser_Id");
            CreateIndex("dbo.Tickets", "AssignedTo_Id");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
