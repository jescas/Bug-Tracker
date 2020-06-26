using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Repositories
{
    public class ProjectRepository
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public ICollection<Project> GetAllProjects()
        {
            var result = db.Projects.ToList();

            return result;
        }
        public ICollection<Project> ProjectsForUser(string userId)
        {
            var result = db.Users.Where(u=>u.Id == userId).Select(p=>p.Projects).FirstOrDefault();

            return result;
        }

        public void AddProject(int projectId)
        {
            var project = db.Projects.FirstOrDefault(p => p.Id == projectId);

            if (project.Id != projectId)
            {
                db.Projects.Add(project);

                db.SaveChanges();
            }
            else
            {
                throw new Exception("Project Already Exists");
            }
        }
    }
}