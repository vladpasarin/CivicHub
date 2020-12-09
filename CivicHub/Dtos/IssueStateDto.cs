using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class IssueStateDto
    {
        public Guid Id { get; set; }
        public Guid IssueId { get; set; }
        //public StateDto State { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string CustomMessage { get; set; }
        //public ICollection<IssueStateComment> IssueStateComments { get; set; }
        //public ICollection<IssueStatePhoto> IssueStatePhotos { get; set; }
        //public ICollection<IssueStateVideo> IssueStateVideos { get; set; }
        //public ICollection<IssueStateReaction> IssueStateReactions { get; set; }
    }
}
