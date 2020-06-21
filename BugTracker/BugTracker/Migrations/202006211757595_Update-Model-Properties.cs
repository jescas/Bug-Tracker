namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Project_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Project_Id");
            AddForeignKey("dbo.Projects", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "Project_Id" });
            DropColumn("dbo.Projects", "Project_Id");
        }
    }
}
