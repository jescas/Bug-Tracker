﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public virtual int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Property { get; set; }
        public double OldValue { get; set; }
        public double NewValue { get; set; }
        public bool Changed { get; set; }
    }
}