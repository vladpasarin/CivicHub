using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class IssueStateCommentPhoto: BaseEntity
    {
        public Guid IssueStateCommentId { get; set; }
        public IssueStateComment IssueStateComment { get; set; }
        public string Photo { get; set; }
    }
}
