using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Ticket
    {
        public Ticket(int id, string title, string description, DateTime created, Project project, TicketType type, TicketPriority priority)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Created = created;
            this.Project = project;
            this.TicketType = type;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool isUpdated { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual int TicketTypeId { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual int TicketPriorityId { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
        public virtual int TicketStatusId { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        //continue
    }
}