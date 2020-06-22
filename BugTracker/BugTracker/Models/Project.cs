using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Project
    {
        public Project()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
            this.Tickets = new HashSet<Ticket>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}