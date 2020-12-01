using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class IssueStatePhoto: BaseEntity
    {
        public Guid IssueStateId { get; set; }
        public IssueState IssueState { get; set; }
        public byte[] Photo { get; set; }
        public DateTime dateAdded { get; set; }
    }
}
