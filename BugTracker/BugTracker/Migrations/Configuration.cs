namespace BugTracker.Migrations
{
    using BugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BugTracker.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!context.Roles.Any())
            {
                UserManager.createRole("Administrator");
                UserManager.createRole("Project Manager");
                UserManager.createRole("Developer");
                UserManager.createRole("Submitter");
            }

            if (!context.Users.Any())
            {
                UserManager.CreateUser("projectmanager1@mail.com");
                UserManager.CreateUser("developer1@mail.com");
                UserManager.CreateUser("submitter1@mail.com");
                UserManager.CreateUser("admin1@mail.com");
            }

            string AdminId = context.Users.FirstOrDefault().Id;

            if (!UserManager.checkUserRole(AdminId, "Administrator"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "admin1@mail.com");

                UserManager.AddUserToRole(AdminId, "Administrator");
            }

            string ProjectManagerId = context.Users.FirstOrDefault().Id;

            if (!UserManager.checkUserRole(ProjectManagerId, "Project Manager"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "projectmanager1@mail.com");

                UserManager.AddUserToRole(ProjectManagerId, "Project Manager");
            }

            string DeveloperId = context.Users.FirstOrDefault().Id;

            if (!UserManager.checkUserRole(DeveloperId, "Developer"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "developer1@mail.com");

                UserManager.AddUserToRole(DeveloperId, "Developer");
            }

            string SubmitterId = context.Users.FirstOrDefault().Id;

            if (!UserManager.checkUserRole(SubmitterId, "Submitter"))
            {
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName == "submitter1@mail.com");

                UserManager.AddUserToRole(SubmitterId, "Submitter");
            }

            
        }
    }
}
