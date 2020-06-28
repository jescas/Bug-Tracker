using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class TicketNotification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public TicketNotification(string title, int ticketId, string applicationUserId)
        {
            this.Title = title;
            this.TicketId = ticketId;
            this.ApplicationUserId = applicationUserId;

        }
    }


}