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

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool Updated { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        //continue
    }
}