using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Ticket
    {
        public Ticket() 
        {
            this.TicketAttachments = new HashSet<TicketAttachment>();
            this.TicketComments = new HashSet<TicketComment>();
            this.TicketHistories = new HashSet<TicketHistory>();
            this.TicketNotifications = new HashSet<TicketNotification>();
        }
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
        //create annotations accordingly
        public virtual int OwnerUserId { get; set; }
        public virtual ApplicationUser OwnerUser { get; set; }
        public virtual int AssignedToUserId { get; set; }
        public virtual ApplicationUser AssignedTo { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual ICollection<TicketNotification> TicketNotifications { get; set; }


    }
}