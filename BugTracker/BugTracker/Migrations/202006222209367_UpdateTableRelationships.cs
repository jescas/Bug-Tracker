namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "Project_Id" });
            AddColumn("dbo.Tickets", "OwnerUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "AssignedToUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "AssignedTo_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "OwnerUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "AssignedTo_Id");
            CreateIndex("dbo.Tickets", "OwnerUser_Id");
            AddForeignKey("dbo.Tickets", "AssignedTo_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "OwnerUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Projects", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Project_Id", c => c.Int());
            DropForeignKey("dbo.Tickets", "OwnerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "AssignedTo_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "OwnerUser_Id" });
            DropIndex("dbo.Tickets", new[] { "AssignedTo_Id" });
            DropColumn("dbo.Tickets", "OwnerUser_Id");
            DropColumn("dbo.Tickets", "AssignedTo_Id");
            DropColumn("dbo.Tickets", "AssignedToUserId");
            DropColumn("dbo.Tickets", "OwnerUserId");
            CreateIndex("dbo.Projects", "Project_Id");
            AddForeignKey("dbo.Projects", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
