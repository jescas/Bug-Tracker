using BugTracker.Models;
using BugTracker.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class UserManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public TicketRepository tr = new TicketRepository();
        public UserManager um = new UserManager();

        // GET: UserManagers
        [Authorize(Roles="Admin, Project Manager")]
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
        //GET
        [Authorize(Roles = "Admin, Project Manager")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        //POST
        [Authorize(Roles = "Admin, Project Manager")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")] IdentityRole role)
        {
            if(ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
            
        }
        [HttpGet]
        public ActionResult AssignDeveloperToProject()
        {
            ViewBag.ProjectName = new SelectList(db.Projects.ToList(), "Name", "Name");
            var developers = db.Roles.Where(r => r.Name == "Developer").Select(u=>u.Users).FirstOrDefault();
            ViewBag.UserName = new SelectList(developers, "UserId", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult AssignDeveloperToProject(ApplicationUser user, Project project)
        {
            if (ModelState.IsValid)
            {
                user.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index", "UserManager");
            }
            ViewBag.ProjectName = new SelectList(db.Projects.ToList(), "Name", "Name");
            var developers = db.Roles.Where(r => r.Name == "Developer").Select(u => u.Users).FirstOrDefault();
            ViewBag.UserName = new SelectList(developers, "UserId", "UserName");
            return View(project);
        }
    }
}