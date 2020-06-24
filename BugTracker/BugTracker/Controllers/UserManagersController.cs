using BugTracker.Models;
using BugTracker.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        //POS
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
        [Authorize(Roles = "Admin, Project Manager")]
        public ActionResult AssignUserToRole()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Project Manager")]
        public ActionResult AssignDeveloperToProject()
        {
            return View();
        }
    }
}