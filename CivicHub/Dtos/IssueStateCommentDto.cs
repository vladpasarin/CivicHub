using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class IssueStateCommentDto
    {
        public Guid Id { get; set; }
        public Guid IssueStateId { get; set; }
        public IssueState IssueState { get; set; }
        public String Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime dateCreated { get; set; }
        public ICollection<IssueStateCommentPhoto> IssueStateCommentPhotos { get; set; }
    }
}
