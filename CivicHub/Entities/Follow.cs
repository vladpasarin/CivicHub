using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class Follow: BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
