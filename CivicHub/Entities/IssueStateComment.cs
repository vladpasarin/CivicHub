using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class IssueStateComment: BaseEntity
    {
        public Guid IssueStateId { get; set; }
        public IssueState IssueState { get; set; }
        public String Text { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime dateCreated { get; set; }
        public ICollection<IssueStateCommentPhoto> IssueStateCommentPhotos { get; set; }
    }
}
