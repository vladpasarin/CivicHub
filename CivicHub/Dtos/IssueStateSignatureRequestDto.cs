using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class IssueStateSignatureRequestDto
    {
        public Guid Id { get; set; }
        public Guid IssueStateId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateSigned { get; set; }
        /*
        public string Cnp { get; set; }
        public string Adresa { get; set; }
        public string SerieBuletin { get; set; }
        public string NumarBuletin { get; set; }
        */
    }
}
