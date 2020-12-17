using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class IssueStateReaction : BaseEntity
    {
        public Guid IssueStateId { get; set; }
        public IssueState IssueState { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public String Vote { get; set; }
        public DateTime dateGiven { get; set; }
    }
}