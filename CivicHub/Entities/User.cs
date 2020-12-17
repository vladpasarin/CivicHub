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
        public byte[] Avatar { get; set; }
        public int Points { get; set; }
        public DateTime DateRegistered { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public ICollection<IssueStateComment> IssueStateComments { get; set; }
        public ICollection<IssueStateReaction> IssueStateReactions { get; set; }
        public ICollection<IssueStateSignature> IssueStateSignatures { get; set; }
    }
}
