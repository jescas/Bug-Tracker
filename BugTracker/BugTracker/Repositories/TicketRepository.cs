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

        public ICollection<string> TicketsForUser(int userId)
        {
            var result = db.Projects.Where(up => up.Id == userId).Select(p => p.Name);
            return result.ToList();
        }
        public void AssignTicketToDeveloper(int developerId, Ticket ticket)
        {
            var developer = db.Users.Find(developerId);

            if(!developer.Tickets.Contains(ticket))
            {
                developer.Tickets.Add(ticket);
            }
        }
    }
}