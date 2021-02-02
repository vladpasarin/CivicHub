using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicHub.Entities
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int Points { get; set; }
        public int PointsUsed { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Cnp { get; set; }
        public string Adresa { get; set; }
        public string SerieBuletin { get; set; }
        public string NumarBuletin { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public ICollection<IssueStateComment> IssueStateComments { get; set; }
        public ICollection<IssueStateReaction> IssueStateReactions { get; set; }
        public ICollection<IssueStateSignature> IssueStateSignatures { get; set; }
        public ICollection<IssueStateCommentLike> IssueStateCommentLikes { get; set; }
        public ICollection<PrizeGiven> PrizeGivens { get; set; }
        public ICollection<Follow> Follows { get; set; }
    }
}
