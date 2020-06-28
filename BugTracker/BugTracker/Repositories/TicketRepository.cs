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

        public IQueryable<Ticket> GetAllTicketsPerAssignment(string userId)
        {
            var result = db.Tickets.Where(t => t.AssignedToUserId == userId);
            return result;
        }

        public IQueryable<Ticket> GetAllTicketsPerOwnership(string submitterId)
        {
            var result = db.Tickets.Where(t => t.OwnerUserId == submitterId);
            return result;
        }

        [Authorize(Roles = "Admin, Project Manager")]
        public void AssignTicketToDeveloper(ApplicationUser developer, Ticket ticket)
        {
            if (UserManager.checkUserRole(developer.Id, "Developer") && !developer.AssignedToTickets.Contains(ticket))
            {
                developer.AssignedToTickets.Add(ticket);
                db.SaveChanges();
            }
        }
    }
}