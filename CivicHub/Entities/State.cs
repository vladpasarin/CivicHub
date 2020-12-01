using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class State: BaseEntity
    {
        public int Type { get; set; }
        public string Message { get; set; }
        public ICollection<IssueState> IssueStates { get; set; }

    }
}
