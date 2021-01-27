using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class IssueStatePhotoDto
    {
        public Guid Id { get; set; }
        public Guid IssueStateId { get; set; }
        public string Photo { get; set; }
        public DateTime dateAdded { get; set; }
    }
}
