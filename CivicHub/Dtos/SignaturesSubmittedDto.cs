using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class SignaturesSubmittedDto
    {
        public Guid IssueId { get; set; }
        public List<string> Photos { get; set; }
    }
}
