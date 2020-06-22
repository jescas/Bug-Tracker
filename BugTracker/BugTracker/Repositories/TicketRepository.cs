using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Repositories
{
    public class TicketRepository
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        
        public Ticket CreateTicket(int id, string title, string description, DateTime created, Project project, TicketType type, TicketPriority priority)
        {
            Ticket newTicket = new Ticket(id, title, description, created, project, type, priority);

            return newTicket;
        }
        public ICollection<Ticket> GetAllTickets()
        {
            var result = db.Tickets.ToList();

            return result;
        }

        public ICollection<string> GetAllTicketsPerAssignment(int userId)
        {
            var result = db.Tickets.Where(t => t.AssignedToUserId == userId).Select(t => t.Title);
            return result.ToList();
        }
        public ICollection<string> GetAllTicketsPerOwnership(int userId)
        {
            var result = db.Tickets.Where(t => t.OwnerUserId == userId).Select(t => t.Title);
            return result.ToList();
        }
        [Authorize(Roles = "Project Manager")]
        public void AssignTicketToDeveloper(ApplicationUser developer, Ticket ticket)
        {
            if (UserManager.checkUserRole(developer.Id, "Developer") && !developer.Tickets.Contains(ticket))
            {
                developer.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }

        public void EditAssignedTickets()
        {

        }

        public void ViewAssignedTickets(int userId)
        {
            
        }

        public void AssignedProjectsTickets(int userId)
        {

        }
    }
}