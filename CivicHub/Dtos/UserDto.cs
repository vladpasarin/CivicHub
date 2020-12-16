using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public byte[] Avatar { get; set; }
        public int Points { get; set; }
        public DateTime DateRegistered { get; set; }
        public List<IssueDto> Issues { get; set; }
    }
}
