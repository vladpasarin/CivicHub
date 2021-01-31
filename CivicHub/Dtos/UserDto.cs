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
        public string Avatar { get; set; }
        public int Points { get; set; }
        public string Cnp { get; set; }
        public string Adresa { get; set; }
        public string SerieBuletin { get; set; }
        public string NumarBuletin { get; set; }
        public DateTime DateRegistered { get; set; }
        public List<IssueDto> Issues { get; set; }
    }
}
