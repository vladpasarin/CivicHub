using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class ResponseGivenDto
    {
        public Guid IssueId { get; set; }
        public List<byte[]> Photos { get; set; }
        public string MessageFromAuthorities { get; set; }
    }
}
