using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class IssueStateCommentLike: BaseEntity
    {
        public Guid IssueStateCommentId { get; set; }
        public IssueStateComment IssueStateComment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
