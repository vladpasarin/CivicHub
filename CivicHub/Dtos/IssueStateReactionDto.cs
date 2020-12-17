using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class IssueStateReactionDto
    {
        public Guid Id { get; set; }
        public Guid IssueStateId { get; set; }
        public Guid UserId { get; set; }
        public int Vote { get; set; }
        public DateTime dateGiven { get; set; }
    }
}
