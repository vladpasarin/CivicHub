using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class Issue: BaseEntity
    {
        public String Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<IssueState> IssueStates { get; set; }
        public ICollection<Follow> Follows { get; set; }

    }
}
