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
        [Authorize(Roles="Administrator, Project Manager")]
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
        //GET
        [Authorize(Roles = "Administrator, Project Manager")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        //POST
        [Authorize(Roles = "Administrator, Project Manager")]
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
        //GET
        [Authorize(Roles = "Administrator, Project Manager")]
        [HttpGet]
        public ActionResult AssignDeveloperToTicket()
        {
            ViewBag.TicketName = new SelectList(db.Tickets.ToList(), "Title", "Title");
            var developers = db.Roles.Where(r => r.Name == "Developer").Select(u=>u.Users).FirstOrDefault();
            ViewBag.UserName = new SelectList(developers, "UserId", "UserName");
            return View();
        }
        //POST
        [Authorize(Roles = "Administrator, Project Manager")]
        [HttpPost]
        public ActionResult AssignDeveloperToTicket(ApplicationUser user, Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                user.AssignedToTickets.Add(ticket);

                if (!db.TicketNotifications.Any())
                {
                    TicketNotification notification = new TicketNotification("New Assigned Ticket", ticket.Id, user.Id);

                    db.TicketNotifications.Add(notification);
                }

                db.SaveChanges();
                return RedirectToAction("Index", "UserManager");
            }

            ViewBag.TicketName = new SelectList(db.Projects.ToList(), "Title", "Title");
            var developers = db.Roles.Where(r => r.Name == "Developer").Select(u => u.Users).FirstOrDefault();
            ViewBag.UserName = new SelectList(developers, "UserId", "UserName");
            return View(ticket);
        }
    }
}